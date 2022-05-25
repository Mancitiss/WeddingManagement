using CryptSharp;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Reflection;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static WeddingManagementServer.Tools;

namespace WeddingManagementServer
{
    internal class Program
    {
        internal static string sqlConnectionString = "Data Source=" +
                        Environment.GetEnvironmentVariable("DBServer", EnvironmentVariableTarget.User) +
                        ";Initial Catalog=" +
                        Environment.GetEnvironmentVariable("DBicatalog_Wedding", EnvironmentVariableTarget.User) +
                        ";User ID=" +
                        Environment.GetEnvironmentVariable("DBusername", EnvironmentVariableTarget.User) +
                        ";Password=" +
                        Environment.GetEnvironmentVariable("DBpassword", EnvironmentVariableTarget.User) +
                        ";MultipleActiveResultSets = true;";
        static X509Certificate serverCertificate = new X509Certificate(@"F:\Python Learning\web_cert2022\server.pfx", Environment.GetEnvironmentVariable("certpass", EnvironmentVariableTarget.User));

        static ConcurrentDictionary<string, Client> sessions = new ConcurrentDictionary<string, Client>();
        static Random rand;
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location));
                rand = new Random();

                using (SqlConnection sql = new SqlConnection(sqlConnectionString))
                {
                    try
                    {
                        sql.Open();
                        Data.InitializeData();
                        sql.Close();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                }
                ExecuteServer();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static void ExecuteServer()
        {
            TcpListener listener = new TcpListener(IPAddress.Any, 11111);
            listener.Start();

            Console.WriteLine("Server at: {0}", IPAddress.Any);

            try
            {

                while (true)
                {
                    //Thread.Sleep(10);
                    TcpClient client = listener.AcceptTcpClient();

                    //Console.WriteLine("Accepted Client");
                    try
                    {
                        ThreadPool.QueueUserWorkItem(Receive_from_socket_not_logged_in, client);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                    client = null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        
        private static async void Receive_from_socket_not_logged_in(object state)
        {
            TcpClient c = state as TcpClient;
            // A client has connected. Create the
            // SslStream using the client's network stream.
            SslStream sslStream = new SslStream(c.GetStream(), false);
            // Authenticate the server but don't require the client to authenticate.
            try
            {
                sslStream.AuthenticateAsServer(serverCertificate, clientCertificateRequired: false, checkCertificateRevocation: true);

                // Display the properties and settings for the authenticated stream.
                /*
                DisplaySecurityLevel(sslStream);
                DisplaySecurityServices(sslStream);
                DisplayCertificateInformation(sslStream);
                DisplayStreamProperties(sslStream);
                */

                SslStream_receive(sslStream, 8, out string data);
                //Console.WriteLine("not logged in:"+data);
                if (data != null && data != "")
                {
                    string instruction = data;
                    if (instruction == "0012") //0012 = work available
                    {
                        SslStream_receive_ASCII(sslStream, 19, out data);
                        sslStream.Dispose();
                        c.Dispose();
                        bool pass = false;
                        if (sessions.ContainsKey(data) && 1 == Interlocked.Exchange(ref sessions[data].is_waited, 1)) pass = true;
                        int h = 0;
                        while (!pass && h++ < 20 && !sessions.ContainsKey(data))
                        {
                            await Task.Delay(1000);
                        }
                        if (!pass && sessions.ContainsKey(data))
                        {
                            try
                            {
                                bool do_work = false;
                                while (1 == Interlocked.Exchange(ref sessions[data].is_locked, 1))
                                {
                                    await Task.Delay(1000);
                                }
                                //Console.WriteLine(item.Key + " is online");
                                if (sessions[data].client.Connected)
                                {
                                    if (sessions[data].client.Available > 0)
                                    {
                                        //sessions[data].loopnum = 0;
                                        if (!sessions[data].client.Connected) // Something bad has happened, shut down
                                        {
                                            try
                                            {
                                                shutdown(data);
                                            }
                                            catch (Exception e)
                                            {
                                                Console.WriteLine(e.ToString());
                                            }
                                        }
                                        else // There is data waiting to be read"
                                        {
                                            try
                                            {
                                                do_work = true;
                                                ThreadPool.QueueUserWorkItem(Receive_message, data);
                                            }
                                            catch (Exception e)
                                            {
                                                exception_handler(new KeyValuePair<string, Client>(data, sessions[data]), e.ToString());
                                                Console.WriteLine(e.ToString());
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    shutdown(data);
                                }
                                if (!do_work) Interlocked.Exchange(ref sessions[data].is_locked, 0);
                            }
                            catch (Exception )
                            {
                                //Console.WriteLine(clientquit.ToString());
                                shutdown(data);
                            }
                            finally
                            {
                                try
                                {
                                    Interlocked.Exchange(ref sessions[data].is_waited, 0);
                                }
                                catch (Exception )
                                {

                                }
                            }
                        }
                    } // 0012 = work available
                    else
                    if (instruction == "0010") // 0010 = log in
                    {
                        Receive_data_automatically(sslStream, out string tk);
                        Receive_data_automatically(sslStream, out string mk);
                        try
                        {
                            string commandtext = "select top 1 id, pw, priority from ACCOUNTS where username=@username";
                            using (SqlConnection sql = new SqlConnection(sqlConnectionString))
                            {
                                sql.Open();
                                using (SqlCommand command = new SqlCommand(commandtext, sql))
                                {
                                    command.Parameters.AddWithValue("@username", tk);
                                    using (SqlDataReader reader = command.ExecuteReader())
                                    {
                                        Console.WriteLine("After avatar");
                                        if (reader.Read())
                                        {
                                            //if (act.pw == reader["pw"].ToString())
                                            if (mk == reader["pw"].ToString() || Crypter.CheckPassword(mk, reader["pw"].ToString()))
                                            {
                                                bool skip = false;
                                                if (mk == reader["pw"].ToString())
                                                {
                                                    using (SqlCommand changepass = new SqlCommand("update top (1) ACCOUNTS set pw = @pw where id = @id", sql))
                                                    {
                                                        changepass.Parameters.AddWithValue("@pw", Crypter.Blowfish.Crypt(mk));
                                                        changepass.Parameters.AddWithValue("@id", reader["id"].ToString());
                                                        changepass.ExecuteNonQuery();
                                                        sslStream.Write(Encoding.Unicode.GetBytes("-200"));
                                                        skip = true;
                                                    }
                                                }
                                                if (!skip)
                                                {
                                                    string id = reader["id"].ToString();
                                                    string str_id = id;
                                                    while (id.Length < 19) id = '0' + id;

                                                    Account account = new Account(id, (short)reader["priority"]);
                                                    String json = Jil.JSON.Serialize<Account>(account);
                                                    sslStream.Write(Encoding.Unicode.GetBytes("0200" + Wrap_data_with_byte(json)));
                                                    Console.WriteLine("Before dictionaries");
                                                    try
                                                    {
                                                        if (sessions.ContainsKey(id))
                                                        {
                                                            try
                                                            {
                                                                Interlocked.Exchange(ref sessions[id].is_locked, 1);
                                                                sessions[id].stream.Write(Encoding.Unicode.GetBytes("2004"));
                                                                Console.WriteLine("User logged in from another device");
                                                            }
                                                            catch (Exception )
                                                            {

                                                            }
                                                            finally
                                                            {
                                                                shutdown(id);
                                                            }

                                                        }
                                                        Client client = new Client();
                                                        Console.WriteLine("got id");
                                                        Int64 id_int = (Int64)reader["id"];
                                                        while (sessions.ContainsKey(id)) await Task.Delay(1000);
                                                        client.client = c;
                                                        client.stream = sslStream;
                                                        client.is_locked = 0;
                                                        client.id = id;
                                                        client.priority = (Int16)reader["priority"];
                                                        sessions.AddOrUpdate(id, client, (key, oldValue) => { shutdown(key); return client; });
                                                        Console.WriteLine("Joined");
                                                    }
                                                    catch (Exception e)
                                                    {
                                                        Console.WriteLine(e.ToString());
                                                        shutdown(str_id);
                                                    }/*
                                                    finally
                                                    {
                                                        is_locked[id] = false;
                                                    }*/
                                                    c = null;
                                                    sslStream = null;
                                                }
                                            }
                                            else
                                            {
                                                try
                                                {
                                                    try
                                                    {
                                                        sslStream.Write(Encoding.Unicode.GetBytes("-200"));
                                                    }
                                                    catch
                                                    {

                                                    }
                                                    try
                                                    {
                                                        sslStream.Dispose();
                                                    }
                                                    catch
                                                    {

                                                    }
                                                    c.Dispose();
                                                }
                                                catch (Exception e)
                                                {
                                                    Console.WriteLine(e.ToString());
                                                }
                                            } // wrong password

                                        }
                                        else
                                        {
                                            try
                                            {
                                                try
                                                {
                                                    sslStream.Write(Encoding.Unicode.GetBytes("-200"));
                                                }
                                                catch
                                                {

                                                }
                                                try
                                                {
                                                    sslStream.Dispose();
                                                }
                                                catch
                                                {

                                                }
                                                c.Dispose();
                                            }
                                            catch (Exception e)
                                            {
                                                Console.WriteLine(e.ToString());
                                            }
                                        } // log-in failed ACCOUNTS doesn't exist
                                    }
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.ToString());
                        }
                    } // 0010 = log in
                    else
                    {
                        try
                        {
                            try
                            {
                                sslStream.Dispose();
                            }
                            catch
                            {

                            }
                            c.Dispose();
                        }
                        catch
                        {

                        }
                    } // release resources, dispose connection etc ..
                }
            }
            catch (AuthenticationException e)
            {
                Console.WriteLine("Exception: {0}", e.Message);
                if (e.InnerException != null)
                {
                    Console.WriteLine("Inner exception: {0}", e.InnerException.Message);
                }
                Console.WriteLine("Authentication failed - closing the connection.");
                try
                {
                    sslStream.Dispose();
                    c.Dispose();
                }
                catch
                {

                }
                return;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                try
                {
                    sslStream.Dispose();
                }
                catch
                {

                }
                try
                {
                    c.Dispose();
                }
                catch
                {

                }
            }
        }

        private static void Receive_message(object state)
        {
            string id = state as string;
            try
            {
                SslStream s = sessions[id].stream;
                string data;
                do
                {
                    if (SslStream_receive(s, 8, out data))
                    {
                        Console.WriteLine("Work: " + data);
                        if (data!= null && data != "")
                        {
                            string instruction = data;
                            switch (instruction)
                            {
                                // create new ACCOUNTS (only recruiters and admins can do this)
                                // return 1011 if success, else 1111
                                case "0011": // register new ACCOUNTS
                                    {
                                        try
                                        {
                                            Receive_data_automatically(s, out string json);
                                            if (sessions[id].priority <= Data.GetRecruiterLevel())
                                            {
                                                Account act = Jil.JSON.Deserialize<Account>(json);
                                                Console.WriteLine(act.username);
                                                Console.WriteLine(act.pw);
                                                if (!check_existed_username(act.username))
                                                {
                                                    Int64 randomid = 0;
                                                    while (randomid <= 0 || check_existed_id(randomid))
                                                    {
                                                        randomid = NextInt64(rand);
                                                    }
                                                    string id_string = randomid.ToString();
                                                    while (id_string.Length < 19) id_string = '0' + id_string;
                                                    using (var sql = new SqlConnection(sqlConnectionString))
                                                    {
                                                        sql.Open();
                                                        using (SqlCommand command = new SqlCommand("insert into ACCOUNTS values (@id, @username, @pw, @priority)", sql))
                                                        {
                                                            command.Parameters.AddWithValue("@id", id_string);
                                                            command.Parameters.AddWithValue("@username", act.username);
                                                            command.Parameters.AddWithValue("@pw", Crypter.Blowfish.Crypt(act.pw));
                                                            command.Parameters.AddWithValue("@priority", act.priority);
                                                            command.ExecuteNonQuery();
                                                        }
                                                        sessions[id].Queue_command(Encoding.Unicode.GetBytes("1011")); // New ACCOUNTS created
                                                    }
                                                }
                                                else
                                                {
                                                    sessions[id].Queue_command(Encoding.Unicode.GetBytes("1111")); // Username exists
                                                }
                                            }
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine(e.ToString());
                                            exception_handler(new KeyValuePair<string, Client>(id, sessions[id]), e.ToString());
                                        }
                                    }
                                    break;


                                // promote/demote ACCOUNTS (only recruiters and admins can do this)
                                // return 2111 if success, else 3111
                                case "0111":
                                    {
                                        Tools.Receive_data_automatically(s, out string json);
                                        Account act = Jil.JSON.Deserialize<Account>(json);
                                        if (sessions[id].priority <= Data.GetRecruiterLevel() && sessions[id].priority < act.priority)
                                        {
                                            Int16 currentPriority;
                                            using (var sql = new SqlConnection(sqlConnectionString))
                                            {
                                                sql.Open();
                                                if (act.id != null)
                                                {
                                                    if (sessions.ContainsKey(act.id))
                                                    {
                                                        currentPriority = sessions[act.id].priority;
                                                    }
                                                    else
                                                    {
                                                        using (SqlCommand command = new SqlCommand("select priority from ACCOUNTS where id = @id", sql))
                                                        {
                                                            command.Parameters.AddWithValue("@id", act.id);
                                                            currentPriority = (Int16)command.ExecuteScalar();
                                                        }
                                                    }
                                                }
                                                else if (act.username != null)
                                                {
                                                    using (SqlCommand command = new SqlCommand("select priority from ACCOUNTS where username = @username", sql))
                                                    {
                                                        command.Parameters.AddWithValue("@username", act.username);
                                                        currentPriority = (Int16)command.ExecuteScalar();
                                                    }
                                                }
                                                else
                                                {
                                                    sessions[id].Queue_command(Encoding.Unicode.GetBytes("-111"));
                                                    break;
                                                }
                                                if (sessions[id].priority < currentPriority)
                                                {
                                                    using (SqlCommand command = new SqlCommand("update ACCOUNTS set priority = @priority where username = @username", sql))
                                                    {
                                                        command.Parameters.AddWithValue("@username", act.username);
                                                        command.Parameters.AddWithValue("@priority", act.priority);
                                                        command.ExecuteNonQuery();
                                                    }
                                                    sessions[id].Queue_command(Encoding.Unicode.GetBytes("2111")); // ACCOUNTS promoted/demoted
                                                }
                                                else
                                                {
                                                    sessions[id].Queue_command(Encoding.Unicode.GetBytes("3111")); // You have no right to do this
                                                }
                                            }    
                                        }
                                        else
                                        {
                                            sessions[id].Queue_command(Encoding.Unicode.GetBytes("3111")); // You have no right to do this
                                        }
                                    }
                                    break;

                                    // get types of lobbies 
                                    // return 0020 + json(List<LobbyType>) in unicode
                                case "0020":
                                    {
                                        List<LobbyType> lobbyTypes = new List<LobbyType>();
                                        using (var sql = new SqlConnection(sqlConnectionString))
                                        {
                                            sql.Open();
                                            using (SqlCommand command = new SqlCommand("select * from LOBBYTYPE where available > 0", sql))
                                            {
                                                using (SqlDataReader reader = command.ExecuteReader())
                                                {
                                                    while (reader.Read())
                                                    {
                                                        lobbyTypes.Add(new LobbyType(reader["idLobbyType"].ToString(), reader["LobbyName"].ToString(), (long)reader["MinTablePrice"]));
                                                    }
                                                }
                                            }
                                        }
                                        sessions[id].Queue_command(Combine(Encoding.Unicode.GetBytes("0020"),
                                            Encoding.Unicode.GetBytes(Wrap_data_with_byte(Jil.JSON.Serialize(lobbyTypes)))));
                                    }
                                    break;

                                // update a type of lobbies
                                case "0120":
                                    {
                                        try
                                        {
                                            Tools.Receive_data_automatically(s, out string json);
                                            LobbyType lobbyType = Jil.JSON.Deserialize<LobbyType>(json);
                                            using (var sql = new SqlConnection(sqlConnectionString))
                                            {
                                                sql.Open();
                                                if (lobbyType.id != null)
                                                {
                                                    if (lobbyType.id.Length == 21)
                                                    {
                                                        string key = lobbyType.id.Substring(0, 2);
                                                        long idl = long.Parse(lobbyType.id.Substring(2));
                                                        if (key.Equals("LT") && check_existed_id(idl, key))
                                                        {
                                                            using (SqlCommand command = new SqlCommand("update LOBBYTYPE set LobbyName = @LobbyName, MinTablePrice = @MinTablePrice where idLobbyType = @idLobbyType", sql))
                                                            {
                                                                command.Parameters.AddWithValue("@idLobbyType", lobbyType.id);
                                                                command.Parameters.AddWithValue("@LobbyName", lobbyType.name);
                                                                command.Parameters.AddWithValue("@MinTablePrice", lobbyType.minTablePrice);
                                                                if (command.ExecuteNonQuery() > 0)
                                                                {
                                                                    sessions[id].Queue_command(Encoding.Unicode.GetBytes("0120")); // Lobby type updated
                                                                }
                                                                else
                                                                {
                                                                    sessions[id].Queue_command(Encoding.Unicode.GetBytes("0220")); // Lobby type not updated
                                                                }
                                                            }
                                                        }
                                                    }
                                                    else if (lobbyType.id.Length == 0) {
                                                        string lobbyId = "LT" + GetNewIdFromTable("LB").ToString();
                                                        using (SqlCommand command = new SqlCommand("insert into LOBBYTYPE (idLobbyType, LobbyName, MinTablePrice) values (@idLobbyType, @LobbyName, @MinTablePrice)", sql))
                                                        {
                                                            command.Parameters.AddWithValue("@idLobbyType", lobbyId);
                                                            command.Parameters.AddWithValue("@LobbyName", lobbyType.name);
                                                            command.Parameters.AddWithValue("@MinTablePrice", lobbyType.minTablePrice);
                                                            if(command.ExecuteNonQuery() > 0)
                                                            {
                                                                sessions[id].Queue_command(Encoding.Unicode.GetBytes("0320" + Wrap_data_with_byte(Jil.JSON.Serialize<LobbyType>(lobbyType)))); // Lobby type added
                                                            }
                                                            else
                                                            {
                                                                sessions[id].Queue_command(Encoding.Unicode.GetBytes("0220")); // Lobby type not updated
                                                            }
                                                        }
                                                    }
                                                    else if (lobbyType.id.Length == 22 && lobbyType.id.StartsWith("-"))
                                                    {
                                                        // delete a lobby type
                                                        string key = lobbyType.id.Substring(1, 2);
                                                        long idl = long.Parse(lobbyType.id.Substring(3));
                                                        if (key.Equals("LT") && check_existed_id(idl, key))
                                                        {
                                                            using (SqlCommand command = new SqlCommand("update LOBBYTYPE set available = 0 where idLobbyType = @idLobbyType", sql))
                                                            {
                                                                command.Parameters.AddWithValue("@idLobbyType", lobbyType.id);
                                                                if (command.ExecuteNonQuery() > 0)
                                                                {
                                                                    sessions[id].Queue_command(Encoding.Unicode.GetBytes("0420" + Wrap_data_with_byte(Jil.JSON.Serialize<LobbyType>(lobbyType)))); // Lobby type deleted
                                                                }
                                                                else
                                                                {
                                                                    sessions[id].Queue_command(Encoding.Unicode.GetBytes("0220")); // Lobby type not deleted
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                                
                                            }
                                        } 
                                        catch (Exception )
                                        {
                                            sessions[id].Queue_command(Encoding.Unicode.GetBytes("0220"));
                                        }
                                    }
                                    break;

  // get list of lobbies
                                case "0021":
                                    {
                                        List<Lobby> lobbies = new List<Lobby>();
                                        using (var sql = new SqlConnection(sqlConnectionString))
                                        {
                                            sql.Open();
                                            using (SqlCommand command = new SqlCommand("select * from LOBBY where available > 0", sql))
                                            {
                                                using (SqlDataReader reader = command.ExecuteReader())
                                                {
                                                    while (reader.Read())
                                                    {
                                                        lobbies.Add(new Lobby(reader["idLobby"].ToString(), reader["idLobbyType"].ToString(), reader["LobbyName"].ToString(), (int)reader["MaxTable"], (bool)reader["Status"]));
                                                    }
                                                }
                                            }
                                        }
                                        sessions[id].Queue_command(Combine(Encoding.Unicode.GetBytes("0021"),
                                            Encoding.Unicode.GetBytes(Wrap_data_with_byte(Jil.JSON.Serialize(lobbies)))));
                                    }
                                    break;

                                // update a lobby
                                case "0121":
                                    {
                                        try
                                        {
                                            Tools.Receive_data_automatically(s, out string json);
                                            Lobby lobby = Jil.JSON.Deserialize<Lobby>(json);
                                            using (var sql = new SqlConnection(sqlConnectionString))
                                            {
                                                sql.Open();
                                                if (lobby.idLobby != null)
                                                {
                                                    if (lobby.idLobby.Length == 21)
                                                    {
                                                        string key = lobby.idLobby.Substring(0, 2);
                                                        long idl = long.Parse(lobby.idLobby.Substring(2));
                                                        if (key.Equals("LB") && check_existed_id(idl, key))
                                                        {
                                                            using (SqlCommand command = new SqlCommand("update LOBBY set idLobbyType = @idLobbyType, LobbyName = @LobbyName, MaxTable = @MaxTable, Status = @Status where idLobby = @idLobby", sql))
                                                            {
                                                                command.Parameters.AddWithValue("@idLobby", lobby.idLobby);
                                                                command.Parameters.AddWithValue("@idLobbyType", lobby.idLobbyType);
                                                                command.Parameters.AddWithValue("@LobbyName", lobby.LobbyName);
                                                                command.Parameters.AddWithValue("@MaxTable", lobby.MaxTable);
                                                                command.Parameters.AddWithValue("@Status", lobby.Status);
                                                                if (command.ExecuteNonQuery() > 0)
                                                                {
                                                                    sessions[id].Queue_command(Combine(Encoding.Unicode.GetBytes("0121" + Wrap_data_with_byte(Jil.JSON.Serialize<Lobby>(lobby))))); // Lobby updated
                                                                }
                                                                else
                                                                {
                                                                    sessions[id].Queue_command(Encoding.Unicode.GetBytes("0221")); // Lobby not updated
                                                                }
                                                            }
                                                        }
                                                    }
                                                    else if (lobby.idLobby.Length == 0)
                                                    {
                                                        string lobbyId = "LB" + GetNewIdFromTable("LB").ToString();
                                                        using (SqlCommand command = new SqlCommand("insert into LOBBY (idLobby, idLobbyType, LobbyName, MaxTable, Status) values (@idLobby, @idLobbyType, @LobbyName, @MaxTable, @Status)", sql))
                                                        {
                                                            command.Parameters.AddWithValue("@idLobby", lobbyId);
                                                            command.Parameters.AddWithValue("@idLobbyType", lobby.idLobbyType);
                                                            command.Parameters.AddWithValue("@LobbyName", lobby.LobbyName);
                                                            command.Parameters.AddWithValue("@MaxTable", lobby.MaxTable);
                                                            command.Parameters.AddWithValue("@Status", lobby.Status);
                                                            if (command.ExecuteNonQuery() > 0)
                                                            {
                                                                sessions[id].Queue_command(Combine(Encoding.Unicode.GetBytes("0321" + Wrap_data_with_byte(Jil.JSON.Serialize<Lobby>(lobby))))); // Lobby added
                                                            }
                                                            else
                                                            {
                                                                sessions[id].Queue_command(Encoding.Unicode.GetBytes("0221")); // Lobby not updated
                                                            }
                                                        }
                                                    }
                                                    else if (lobby.idLobby.Length == 22 && lobby.idLobby.StartsWith("-"))
                                                    {
                                                        // delete a lobby
                                                        string key = lobby.idLobby.Substring(1, 2);
                                                        long idl = long.Parse(lobby.idLobby.Substring(3));
                                                        if (key.Equals("LB") && check_existed_id(idl, key))
                                                        {
                                                            using (SqlCommand command = new SqlCommand("update LOBBY set available = 0 where idLobby = @idLobby", sql))
                                                            {
                                                                command.Parameters.AddWithValue("@idLobby", lobby.idLobby);
                                                                if (command.ExecuteNonQuery() > 0)
                                                                {
                                                                    sessions[id].Queue_command(Encoding.Unicode.GetBytes("0421")); // Lobby deleted
                                                                }
                                                                else
                                                                {
                                                                    sessions[id].Queue_command(Encoding.Unicode.GetBytes("0221")); // Lobby not deleted
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        catch (Exception )
                                        {
                                            sessions[id].Queue_command(Encoding.Unicode.GetBytes("0221"));
                                        }
                                    }
                                    break;
                                    

                                // get list of shifts
                                case "0022":
                                    {
                                        List<Shift> shifts = new List<Shift>();
                                        using (var sql = new SqlConnection(sqlConnectionString))
                                        {
                                            sql.Open();
                                            using (SqlCommand command = new SqlCommand("select * from SHIFT where available > 0", sql))
                                            {
                                                using (SqlDataReader reader = command.ExecuteReader())
                                                {
                                                    while (reader.Read())
                                                    {
                                                        shifts.Add(new Shift(reader["idShift"].ToString(), (DateTime)reader["Starting"], (DateTime)reader["Ending"]));
                                                    }
                                                }
                                            }
                                        }
                                        sessions[id].Queue_command(Combine(Encoding.Unicode.GetBytes("0022"),
                                            Encoding.Unicode.GetBytes(Wrap_data_with_byte(Jil.JSON.Serialize(shifts)))));
                                    }
                                    break;

                                // update a shift
                                case "0122":
                                    {
                                        try
                                        {
                                            Tools.Receive_data_automatically(s, out string json);
                                            Shift shift = Jil.JSON.Deserialize<Shift>(json);
                                            using (var sql = new SqlConnection(sqlConnectionString))
                                            {
                                                sql.Open();
                                                if (shift.idShift != null)
                                                {
                                                    if (shift.idShift.Length == 21)
                                                    {
                                                        string key = shift.idShift.Substring(0, 2);
                                                        long idl = long.Parse(shift.idShift.Substring(2));
                                                        if (key.Equals("SH") && check_existed_id(idl, key))
                                                        {
                                                            using (SqlCommand command = new SqlCommand("update SHIFT set Starting = @Starting, Ending = @Ending where idShift = @idShift", sql))
                                                            {
                                                                command.Parameters.AddWithValue("@idShift", shift.idShift);
                                                                command.Parameters.AddWithValue("@Starting", shift.Starting);
                                                                command.Parameters.AddWithValue("@Ending", shift.Ending);
                                                                if (command.ExecuteNonQuery() > 0)
                                                                {
                                                                    sessions[id].Queue_command(Encoding.Unicode.GetBytes("0122" + Wrap_data_with_byte(Jil.JSON.Serialize<Shift>(shift)))); // Shift updated
                                                                }
                                                                else
                                                                {
                                                                    sessions[id].Queue_command(Encoding.Unicode.GetBytes("0222")); // Shift not updated
                                                                }
                                                            }
                                                        }
                                                    }
                                                    else if (shift.idShift.Length == 0)
                                                    {
                                                        string shiftId = "SH" + GetNewIdFromTable("SH").ToString();
                                                        using (SqlCommand command = new SqlCommand("insert into SHIFT (idShift, Starting, Ending) values (@idShift, @Starting, @Ending)", sql))
                                                        {
                                                            command.Parameters.AddWithValue("@idShift", shiftId);
                                                            command.Parameters.AddWithValue("@Starting", shift.Starting);
                                                            command.Parameters.AddWithValue("@Ending", shift.Ending);
                                                            if (command.ExecuteNonQuery() > 0)
                                                            {
                                                                sessions[id].Queue_command(Encoding.Unicode.GetBytes("0322" + Wrap_data_with_byte(Jil.JSON.Serialize<Shift>(shift)))); // Shift added
                                                            }
                                                            else
                                                            {
                                                                sessions[id].Queue_command(Encoding.Unicode.GetBytes("0222")); // Shift not updated
                                                            }
                                                        }
                                                    }
                                                    else if (shift.idShift.Length == 22 && shift.idShift.StartsWith("-"))
                                                    {
                                                        // delete a shift
                                                        string key = shift.idShift.Substring(1, 2);
                                                        long idl = long.Parse(shift.idShift.Substring(3));
                                                        if (key.Equals("SH") && check_existed_id(idl, key))
                                                        {
                                                            using (SqlCommand command = new SqlCommand("update SHIFT set available = 0 where idShift = @idShift", sql))
                                                            {
                                                                command.Parameters.AddWithValue("@idShift", shift.idShift);
                                                                if (command.ExecuteNonQuery() > 0)
                                                                {
                                                                    sessions[id].Queue_command(Encoding.Unicode.GetBytes("0422" + Wrap_data_with_byte(Jil.JSON.Serialize<Shift>(shift)))); // Shift deleted
                                                                }
                                                                else
                                                                {
                                                                    sessions[id].Queue_command(Encoding.Unicode.GetBytes("0222")); // Shift not deleted
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        catch (Exception)
                                        {
                                            sessions[id].Queue_command(Encoding.Unicode.GetBytes("0222"));
                                        }
                                    }
                                    break;

                                // get list of weddings
                                case "0023":
                                    {
                                        List<WeddingInfo> weddings = new List<WeddingInfo>();
                                        using (var sql = new SqlConnection(sqlConnectionString))
                                        {
                                            sql.Open();
                                            using (SqlCommand command = new SqlCommand("select * from WEDDING where available > 0", sql))
                                            {
                                                using (SqlDataReader reader = command.ExecuteReader())
                                                {
                                                    while (reader.Read())
                                                    {
                                                        weddings.Add(new WeddingInfo(
                                                            reader["idWedding"].ToString(),
                                                            reader["idLobby"].ToString(),
                                                            reader["idShift"].ToString(), 
                                                            (DateTime)reader["BookingDate"], 
                                                            (DateTime)reader["WeddingDate"], 
                                                            reader["PhoneNumber"].ToString(),
                                                            reader["BroomName"].ToString(),
                                                            reader["BrideName"].ToString(),
                                                            (int)reader["AmountOfTable"],
                                                            (int)reader["AmountOfContingencyTable"],
                                                            (long)reader["TablePrice"],
                                                            (long)reader["Deposit"]
                                                            ));
                                                    }
                                                }
                                            }
                                            
                                        }
                                        sessions[id].Queue_command(Combine(Encoding.Unicode.GetBytes("0023"),
                                            Encoding.Unicode.GetBytes(Wrap_data_with_byte(Jil.JSON.Serialize(weddings)))));
                                    }
                                    break;

                                // update a wedding
                                case "0123":
                                    {
                                        try
                                        {
                                            Tools.Receive_data_automatically(s, out string json);
                                            WeddingInfo wedding = Jil.JSON.Deserialize<WeddingInfo>(json);
                                            using (var sql = new SqlConnection(sqlConnectionString))
                                            {
                                                sql.Open();
                                                if (wedding.idWedding != null)
                                                {
                                                    if (wedding.idWedding.Length == 21)
                                                    {
                                                        string key = wedding.idWedding.Substring(0, 2);
                                                        long idl = long.Parse(wedding.idWedding.Substring(2));
                                                        if (key.Equals("WE") && check_existed_id(idl, key))
                                                        {
                                                            using (SqlCommand command = new SqlCommand("update WEDDING set idLobby = @idLobby, idShift = @idShift, BookingDate = @BookingDate, WeddingDate = @WeddingDate, PhoneNumber = @PhoneNumber, BroomName = @BroomName, BrideName = @BrideName, AmountOfTable = @AmountOfTable, AmountOfContingencyTable = @AmountOfContingencyTable, TablePrice = @TablePrice, Deposit = @Deposit where idWedding = @idWedding", sql))
                                                            {
                                                                command.Parameters.AddWithValue("@idWedding", wedding.idWedding);
                                                                command.Parameters.AddWithValue("@idLobby", wedding.idLobby);
                                                                command.Parameters.AddWithValue("@idShift", wedding.idShift);
                                                                command.Parameters.AddWithValue("@BookingDate", wedding.BookingDate);
                                                                command.Parameters.AddWithValue("@WeddingDate", wedding.WeddingDate);
                                                                command.Parameters.AddWithValue("@PhoneNumber", wedding.PhoneNumber);
                                                                command.Parameters.AddWithValue("@BroomName", wedding.BroomName);
                                                                command.Parameters.AddWithValue("@BrideName", wedding.BrideName);
                                                                command.Parameters.AddWithValue("@AmountOfTable", wedding.AmountOfTable);
                                                                command.Parameters.AddWithValue("@AmountOfContingencyTable", wedding.AmountOfContingencyTable);
                                                                command.Parameters.AddWithValue("@TablePrice", wedding.TablePrice);
                                                                command.Parameters.AddWithValue("@Deposit", wedding.Deposit);
                                                                if (command.ExecuteNonQuery() > 0)
                                                                {
                                                                    sessions[id].Queue_command(Encoding.Unicode.GetBytes("0123" + Wrap_data_with_byte(Jil.JSON.Serialize<WeddingInfo>(wedding)))); // Wedding updated
                                                                }
                                                                else
                                                                {
                                                                    sessions[id].Queue_command(Encoding.Unicode.GetBytes("0223")); // Wedding not updated
                                                                }
                                                            }
                                                        }
                                                    }
                                                    else if (wedding.idWedding.Length == 0)
                                                    {
                                                        string idWD = "WD" + GetNewIdFromTable("WD").ToString();
                                                        using (SqlCommand command = new SqlCommand("insert into WEDDING (idWedding, idLobby, idShift, BookingDate, WeddingDate, PhoneNumber, BroomName, BrideName, AmountOfTable, AmountOfContingencyTable, TablePrice, Deposit) values (@idWedding, @idLobby, @idShift, @BookingDate, @WeddingDate, @PhoneNumber, @BroomName, @BrideName, @AmountOfTable, @AmountOfContingencyTable, @TablePrice, @Deposit)", sql))
                                                        {
                                                            command.Parameters.AddWithValue("@idWedding", idWD);
                                                            command.Parameters.AddWithValue("@idLobby", wedding.idLobby);
                                                            command.Parameters.AddWithValue("@idShift", wedding.idShift);
                                                            command.Parameters.AddWithValue("@BookingDate", wedding.BookingDate);
                                                            command.Parameters.AddWithValue("@WeddingDate", wedding.WeddingDate);
                                                            command.Parameters.AddWithValue("@PhoneNumber", wedding.PhoneNumber);
                                                            command.Parameters.AddWithValue("@BroomName", wedding.BroomName);
                                                            command.Parameters.AddWithValue("@BrideName", wedding.BrideName);
                                                            command.Parameters.AddWithValue("@AmountOfTable", wedding.AmountOfTable);
                                                            command.Parameters.AddWithValue("@AmountOfContingencyTable", wedding.AmountOfContingencyTable);
                                                            command.Parameters.AddWithValue("@TablePrice", wedding.TablePrice);
                                                            command.Parameters.AddWithValue("@Deposit", wedding.Deposit);
                                                            if (command.ExecuteNonQuery() > 0)
                                                            {
                                                                sessions[id].Queue_command(Encoding.Unicode.GetBytes("0323" + Wrap_data_with_byte(Jil.JSON.Serialize<WeddingInfo>(wedding)))); // Wedding added
                                                            }
                                                            else
                                                            {
                                                                sessions[id].Queue_command(Encoding.Unicode.GetBytes("0223")); // Wedding not updated
                                                            }
                                                        }
                                                    }
                                                    else if (wedding.idWedding.Length == 22 && wedding.idWedding.StartsWith("-"))
                                                    {
                                                        string key = wedding.idWedding.Substring(1, 2);
                                                        long idl = long.Parse(wedding.idWedding.Substring(3));
                                                        if (key.Equals("WE") && check_existed_id(idl, key))
                                                        {
                                                            // delete
                                                            using (SqlCommand command = new SqlCommand("update WEDDING set available = 0 where idWedding = @idWedding", sql))
                                                            {
                                                                command.Parameters.AddWithValue("@idWedding", wedding.idWedding);
                                                                if (command.ExecuteNonQuery() > 0)
                                                                {
                                                                    sessions[id].Queue_command(Encoding.Unicode.GetBytes("0423" + Wrap_data_with_byte(Jil.JSON.Serialize<WeddingInfo>(wedding)))); // Wedding deleted
                                                                }
                                                                else
                                                                {
                                                                    sessions[id].Queue_command(Encoding.Unicode.GetBytes("0223")); // Wedding not deleted
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        catch (Exception)
                                        {
                                            sessions[id].Queue_command(Encoding.Unicode.GetBytes("0223"));
                                        }
                                    }
                                    break;

                                // get list of menus
                                case "0024":
                                    {
                                        List<Menu> menus = new List<Menu>();
                                        using (var sql = new SqlConnection(sqlConnectionString))
                                        {
                                            sql.Open();
                                            using (SqlCommand command = new SqlCommand("select * from MENU where available > 0", sql))
                                            {
                                                using (SqlDataReader reader = command.ExecuteReader())
                                                {
                                                    while (reader.Read())
                                                    {
                                                        menus.Add(new Menu(reader["idDishes"].ToString(), reader["DishesName"].ToString(), (long)reader["DishesPrice"], reader["Note"].ToString()));
                                                    }
                                                }
                                            }
                                        }
                                        sessions[id].Queue_command(Combine(Encoding.Unicode.GetBytes("0024"),
                                            Encoding.Unicode.GetBytes(Wrap_data_with_byte(Jil.JSON.Serialize(menus)))));
                                    }
                                    break;

                                // update a menu
                                case "0124":
                                    {
                                        try
                                        {
                                            Tools.Receive_data_automatically(s, out string json);
                                            Menu menu = Jil.JSON.Deserialize<Menu>(json);
                                            using (var sql = new SqlConnection(sqlConnectionString))
                                            {
                                                sql.Open();
                                                if (menu.idDishes != null)
                                                {
                                                    if (menu.idDishes.Length == 21)
                                                    {
                                                        string key = menu.idDishes.Substring(0, 2);
                                                        long idl = long.Parse(menu.idDishes.Substring(2));
                                                        if (key.Equals("ME") && check_existed_id(idl, key))
                                                        {
                                                            using (SqlCommand command = new SqlCommand("update MENU set DishesName = @DishesName, DishesPrice = @DishesPrice, Note = @Note where idDishes = @idDishes", sql))
                                                            {
                                                                command.Parameters.AddWithValue("@idDishes", menu.idDishes);
                                                                command.Parameters.AddWithValue("@DishesName", menu.DishesName);
                                                                command.Parameters.AddWithValue("@DishesPrice", menu.DishesPrice);
                                                                command.Parameters.AddWithValue("@Note", menu.Note);
                                                                if (command.ExecuteNonQuery() > 0)
                                                                {
                                                                    sessions[id].Queue_command(Encoding.Unicode.GetBytes("0124" + Wrap_data_with_byte(Jil.JSON.Serialize<Menu>(menu)))); // Menu updated
                                                                }
                                                                else
                                                                {
                                                                    sessions[id].Queue_command(Encoding.Unicode.GetBytes("0224")); // Menu not updated
                                                                }
                                                            }
                                                        }
                                                    }
                                                    if (menu.idDishes.Length == 0)
                                                    {
                                                        string idDish = "MN" + GetNewIdFromTable("MN").ToString();
                                                        using (SqlCommand command = new SqlCommand("insert into MENU (idDishes, DishesName, DishesPrice, Note) values (@idDishes, @DishesName, @DishesPrice, @Note)", sql))
                                                        {
                                                            command.Parameters.AddWithValue("@idDishes", idDish);
                                                            command.Parameters.AddWithValue("@DishesName", menu.DishesName);
                                                            command.Parameters.AddWithValue("@DishesPrice", menu.DishesPrice);
                                                            command.Parameters.AddWithValue("@Note", menu.Note);
                                                            if (command.ExecuteNonQuery() > 0)
                                                            {
                                                                sessions[id].Queue_command(Encoding.Unicode.GetBytes("0324" + Wrap_data_with_byte(Jil.JSON.Serialize<Menu>(menu)))); // Menu added

                                                            }
                                                            else
                                                            {
                                                                sessions[id].Queue_command(Encoding.Unicode.GetBytes("0224")); // Menu not added
                                                            }
                                                        }
                                                    }
                                                    else if (menu.idDishes.Length == 22 && menu.idDishes.StartsWith("-"))
                                                    {
                                                        string key = menu.idDishes.Substring(1, 2);
                                                        long idl = long.Parse(menu.idDishes.Substring(3));
                                                        if (key.Equals("MN") && check_existed_id(idl, key))
                                                        {
                                                            using (SqlCommand command = new SqlCommand("update MENU set available = 0 where idDishes = @idDishes", sql))
                                                            {
                                                                command.Parameters.AddWithValue("@idDishes", menu.idDishes);
                                                                if (command.ExecuteNonQuery() > 0)
                                                                {
                                                                    sessions[id].Queue_command(Encoding.Unicode.GetBytes("0424" + Wrap_data_with_byte(Jil.JSON.Serialize<Menu>(menu)))); // Menu deleted
                                                                }
                                                                else
                                                                {
                                                                    sessions[id].Queue_command(Encoding.Unicode.GetBytes("0224")); // Menu not deleted
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        catch (Exception)
                                        {
                                            sessions[id].Queue_command(Encoding.Unicode.GetBytes("0224"));
                                        }
                                    }
                                    break;
                                    

                                // get list of services
                                case "0025":
                                    {
                                        List<Service> services = new List<Service>();
                                        using (var sql = new SqlConnection(sqlConnectionString))
                                        {
                                            sql.Open();
                                            using (SqlCommand command = new SqlCommand("select * from SERVICE where available > 0", sql))
                                            {
                                                using (SqlDataReader reader = command.ExecuteReader())
                                                {
                                                    while (reader.Read())
                                                    {
                                                        services.Add(new Service(reader["idService"].ToString(), reader["ServiceName"].ToString(), (long)reader["ServicePrice"], reader["Note"].ToString()));
                                                    }
                                                }
                                            }
                                        }
                                        sessions[id].Queue_command(Combine(Encoding.Unicode.GetBytes("0025"),
                                            Encoding.Unicode.GetBytes(Wrap_data_with_byte(Jil.JSON.Serialize(services)))));
                                    }
                                    break;

                                // update a service
                                case "0125":
                                    {
                                        try
                                        {
                                            Tools.Receive_data_automatically(s, out string json);
                                            Service service = Jil.JSON.Deserialize<Service>(json);
                                            using (var sql = new SqlConnection(sqlConnectionString))
                                            {
                                                sql.Open();
                                                if (service.idService != null)
                                                {
                                                    if (service.idService.Length == 21)
                                                    {
                                                        string key = service.idService.Substring(0, 2);
                                                        long idl = long.Parse(service.idService.Substring(2));
                                                        if (key.Equals("SE") && check_existed_id(idl, key))
                                                        {
                                                            using (SqlCommand command = new SqlCommand("update SERVICE set ServiceName = @ServiceName, ServicePrice = @ServicePrice, Note = @Note where idService = @idService", sql))
                                                            {
                                                                command.Parameters.AddWithValue("@idService", service.idService);
                                                                command.Parameters.AddWithValue("@ServiceName", service.ServiceName);
                                                                command.Parameters.AddWithValue("@ServicePrice", service.ServicePrice);
                                                                command.Parameters.AddWithValue("@Note", service.Note);
                                                                if (command.ExecuteNonQuery() > 0)
                                                                {
                                                                    sessions[id].Queue_command(Encoding.Unicode.GetBytes("0125" + Wrap_data_with_byte(Jil.JSON.Serialize<Service>(service)))); // Service updated
                                                                }
                                                                else
                                                                {
                                                                    sessions[id].Queue_command(Encoding.Unicode.GetBytes("0225")); // Service not updated
                                                                }
                                                            }
                                                        }
                                                    }
                                                    else if (service.idService.Length == 0)
                                                    {
                                                        string idService = "SE" + GetNewIdFromTable("SE").ToString();
                                                        using (SqlCommand command = new SqlCommand("insert into SERVICE (idService, ServiceName, ServicePrice, Note) values (@idService, @ServiceName, @ServicePrice, @Note)", sql))
                                                        {
                                                            command.Parameters.AddWithValue("@idService", idService);
                                                            command.Parameters.AddWithValue("@ServiceName", service.ServiceName);
                                                            command.Parameters.AddWithValue("@ServicePrice", service.ServicePrice);
                                                            command.Parameters.AddWithValue("@Note", service.Note);
                                                            if (command.ExecuteNonQuery() > 0)
                                                            {
                                                                sessions[id].Queue_command(Encoding.Unicode.GetBytes("0325" + Wrap_data_with_byte(Jil.JSON.Serialize<Service>(service)))); // Service added
                                                            }
                                                            else
                                                            {
                                                                sessions[id].Queue_command(Encoding.Unicode.GetBytes("0225")); // Service not added
                                                            }
                                                        }
                                                    }
                                                    else if (service.idService.Length == 22 && service.idService.StartsWith("-"))
                                                    {
                                                        string key = service.idService.Substring(1, 2);
                                                        long idl = long.Parse(service.idService.Substring(3));
                                                        if (key.Equals("SE") && check_existed_id(idl, key))
                                                        {
                                                            using (SqlCommand command = new SqlCommand("update SERVICE set available = 0 where idService = @idService", sql))
                                                            {
                                                                command.Parameters.AddWithValue("@idService", service.idService);
                                                                if (command.ExecuteNonQuery() > 0)
                                                                {
                                                                    sessions[id].Queue_command(Encoding.Unicode.GetBytes("0425" + Wrap_data_with_byte(Jil.JSON.Serialize<Service>(service)))); // Service deleted
                                                                }
                                                                else
                                                                {
                                                                    sessions[id].Queue_command(Encoding.Unicode.GetBytes("0225")); // Service not deleted
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        catch (Exception)
                                        {
                                            sessions[id].Queue_command(Encoding.Unicode.GetBytes("0223"));
                                        }
                                    }
                                    break;

                                // get list of Table Details of 1 wedding
                                // input: idWedding (21 bytes ASCII)
                                case "0026":
                                    {
                                        // receive wedding id
                                        Tools.SslStream_receive_ASCII(s, 21, out string idWedding);
                                        List<TableDetail> tableDetails = new List<TableDetail>();
                                        using (var sql = new SqlConnection(sqlConnectionString))
                                        {
                                                sql.Open();
                                                using (SqlCommand command = new SqlCommand("select * from TABLE_DETAIL where idWedding = @idWedding", sql))
                                                {
                                                    command.Parameters.AddWithValue("@idWedding", idWedding);
                                                    using (SqlDataReader reader = command.ExecuteReader())
                                                    {
                                                        while (reader.Read())
                                                        {
                                                            tableDetails.Add(new TableDetail(reader["idWedding"].ToString(), reader["idDishes"].ToString(), (int)reader["AmountOfDishes"], (long)reader["TotalDishesPrice"], reader["Note"].ToString()));
                                                        }
                                                    }
                                                }
                                        }
                                        sessions[id].Queue_command(Combine(Encoding.Unicode.GetBytes("0026"),
                                            Encoding.Unicode.GetBytes(Wrap_data_with_byte(Jil.JSON.Serialize(tableDetails)))));
                                    }
                                    break;

                                // update a table detail
                                case "0126":
                                    {
                                        try
                                        {
                                            Tools.Receive_data_automatically(s, out string json);
                                            TableDetail tableDetail = Jil.JSON.Deserialize<TableDetail>(json);
                                            using (var sql = new SqlConnection(sqlConnectionString))
                                            {
                                                sql.Open();
                                                if (tableDetail.idWedding != null && tableDetail.idWedding.Length == 21)
                                                {
                                                    // select wedding with id = tableDetail.idWedding
                                                    using (SqlCommand select = new SqlCommand("select * from WEDDING_INFOR where idWedding = @idWedding")) {
                                                        select.Parameters.AddWithValue("@idWedding", tableDetail.idWedding);
                                                        using (SqlDataReader selectReader = select.ExecuteReader())
                                                        {
                                                            if (selectReader.Read())
                                                            {
                                                                if (tableDetail.idDishes != null)
                                                                {
                                                                    if (tableDetail.idDishes.Length == 22 && tableDetail.idDishes.StartsWith("+"))
                                                                    {
                                                                        string key = tableDetail.idDishes.Substring(1, 2);
                                                                        long idl = long.Parse(tableDetail.idDishes.Substring(3));
                                                                        if (key.Equals("MN") && check_existed_id(idl, key))
                                                                        {
                                                                            using (SqlCommand command = new SqlCommand("update TABLE_DETAIL set idDishes = @idDishes, AmountOfDishes = @AmountOfDishes, TotalDishesPrice = @TotalDishesPrice, Note = @Note where idWedding = @idWedding", sql))
                                                                            {
                                                                                command.Parameters.AddWithValue("@idWedding", tableDetail.idWedding);
                                                                                command.Parameters.AddWithValue("@idDishes", tableDetail.idDishes);
                                                                                command.Parameters.AddWithValue("@AmountOfDishes", tableDetail.AmountOfDishes);
                                                                                command.Parameters.AddWithValue("@TotalDishesPrice", tableDetail.TotalDishesPrice);
                                                                                command.Parameters.AddWithValue("@Note", tableDetail.Note);
                                                                                if (command.ExecuteNonQuery() > 0)
                                                                                {
                                                                                    sessions[id].Queue_command(Encoding.Unicode.GetBytes("0326" + Wrap_data_with_byte(Jil.JSON.Serialize<TableDetail>(tableDetail)))); // Table detail added
                                                                                }
                                                                                else
                                                                                {
                                                                                    sessions[id].Queue_command(Encoding.Unicode.GetBytes("0226")); // Table detail not updated
                                                                                }
                                                                            }
                                                                        }
                                                                        else throw new Exception("Invalid idDishes");
                                                                    }
                                                                    else if (tableDetail.idDishes.Length == 21)
                                                                    {
                                                                        string key = tableDetail.idWedding.Substring(0, 2);
                                                                        long idl = long.Parse(tableDetail.idWedding.Substring(2));
                                                                        if (key.Equals("WE") && check_existed_id(idl, key))
                                                                        {
                                                                            using (SqlCommand command = new SqlCommand("update TABLE_DETAIL set AmountOfDishes = @AmountOfDishes, TotalDishesPrice = @TotalDishesPrice, Note = @Note where idWedding = @idWedding and idDishes = @idDishes", sql))
                                                                            {
                                                                                command.Parameters.AddWithValue("@idWedding", tableDetail.idWedding);
                                                                                command.Parameters.AddWithValue("@idDishes", tableDetail.idDishes);
                                                                                command.Parameters.AddWithValue("@AmountOfDishes", tableDetail.AmountOfDishes);
                                                                                command.Parameters.AddWithValue("@TotalDishesPrice", tableDetail.TotalDishesPrice);
                                                                                command.Parameters.AddWithValue("@Note", tableDetail.Note);
                                                                                if (command.ExecuteNonQuery() > 0)
                                                                                {
                                                                                    sessions[id].Queue_command(Encoding.Unicode.GetBytes("0126" + Wrap_data_with_byte(Jil.JSON.Serialize<TableDetail>(tableDetail)))); // Table detail updated
                                                                                }
                                                                                else
                                                                                {
                                                                                    sessions[id].Queue_command(Encoding.Unicode.GetBytes("0226")); // Table detail not updated
                                                                                }
                                                                            }
                                                                        }
                                                                        else throw new Exception("Invalid idDishes");
                                                                    }
                                                                    else if (tableDetail.idDishes.Length == 22 && tableDetail.idDishes.StartsWith("-"))
                                                                    {
                                                                        string key = tableDetail.idWedding.Substring(0, 2);
                                                                        long idl = long.Parse(tableDetail.idWedding.Substring(2));
                                                                        if (key.Equals("WE") && check_existed_id(idl, key))
                                                                        {
                                                                            using (SqlCommand command = new SqlCommand("delete from TABLE_DETAIL where idWedding = @idWedding and idDishes = @idDishes", sql))
                                                                            {
                                                                                command.Parameters.AddWithValue("@idWedding", tableDetail.idWedding);
                                                                                command.Parameters.AddWithValue("@idDishes", tableDetail.idDishes);
                                                                                if (command.ExecuteNonQuery() > 0)
                                                                                {
                                                                                    sessions[id].Queue_command(Encoding.Unicode.GetBytes("0426" + Wrap_data_with_byte(Jil.JSON.Serialize<TableDetail>(tableDetail)))); // Table detail deleted
                                                                                }
                                                                                else
                                                                                {
                                                                                    sessions[id].Queue_command(Encoding.Unicode.GetBytes("0226")); // Table detail not deleted
                                                                                }
                                                                            }
                                                                        }
                                                                        else throw new Exception("Invalid idDishes");
                                                                    }
                                                                }
                                                                else throw new Exception("Invalid idDishes");
                                                            }
                                                            else throw new Exception("Invalid idWedding");
                                                        }
                                                    }
                                                }
                                                else throw new Exception("Invalid idWedding");
                                            }
                                        }
                                        catch (Exception) { sessions[id].Queue_command(Encoding.Unicode.GetBytes("0223")); }
                                    }
                                    break;

                                // get list of service details
                                case "0027":
                                    {
                                        List<ServiceDetail> services = new List<ServiceDetail>();
                                        using (var sql = new SqlConnection(sqlConnectionString))
                                        {
                                            sql.Open();
                                            using (SqlCommand command = new SqlCommand("select * from SERVICE_DETAIL", sql))
                                            {
                                                using (SqlDataReader reader = command.ExecuteReader())
                                                {
                                                    while (reader.Read())
                                                    {
                                                        services.Add(new ServiceDetail(reader["idWedding"].ToString(), reader["idService"].ToString(), (int)reader["AmountOfService"], (long)reader["TotalServicePrice"], reader["Note"].ToString()));
                                                    }
                                                }
                                            }
                                        }
                                        sessions[id].Queue_command(Combine(Encoding.Unicode.GetBytes("0027"),
                                            Encoding.Unicode.GetBytes(Wrap_data_with_byte(Jil.JSON.Serialize(services)))));
                                    }
                                    break;

                                // update a service detail
                                case "0127":
                                    {
                                        try
                                        {
                                            if (Receive_data_automatically(s, out string json))
                                            {
                                                ServiceDetail serviceDetail = Jil.JSON.Deserialize<ServiceDetail>(json);
                                                using (var sql = new SqlConnection(sqlConnectionString))
                                                {
                                                    sql.Open();
                                                    if (serviceDetail.idWedding.Length == 21)
                                                    {
                                                        // select wedding with idWedding = serviceDetail.idWedding
                                                        using (SqlCommand select = new SqlCommand("select * from WEDDING_INFOR where idWedding = @idWedding"))
                                                        {
                                                            select.Parameters.AddWithValue("@idWedding", serviceDetail.idWedding);
                                                            using (SqlDataReader reader = select.ExecuteReader())
                                                            {
                                                                if (reader.Read())
                                                                {
                                                                    // update service detail
                                                                    if (serviceDetail.idService.Length == 22 && serviceDetail.idService.StartsWith("+"))
                                                                    {
                                                                        string key = serviceDetail.idService.Substring(1, 2);
                                                                        long idl = long.Parse(serviceDetail.idService.Substring(3));
                                                                        if (key.Equals("SE") && check_existed_id(idl, key))
                                                                        {
                                                                            using (SqlCommand command = new SqlCommand("insert into SERVICE_DETAIL (idWedding, idService, @AmountOfService, @TotalServicePrice, @Note) values (@idWedding, @idService, @AmountOfService, @TotalServicePrice, @Note)", sql))
                                                                            {
                                                                                command.Parameters.AddWithValue("@idWedding", serviceDetail.idWedding);
                                                                                command.Parameters.AddWithValue("@idService", serviceDetail.idService);
                                                                                command.Parameters.AddWithValue("@AmountOfService", serviceDetail.AmountOfService);
                                                                                command.Parameters.AddWithValue("@TotalServicePrice", serviceDetail.TotalServicePrice);
                                                                                command.Parameters.AddWithValue("@Note", serviceDetail.Note);
                                                                                if (command.ExecuteNonQuery() > 0)
                                                                                {
                                                                                    sessions[id].Queue_command(Encoding.Unicode.GetBytes("0327" + Wrap_data_with_byte(Jil.JSON.Serialize<ServiceDetail>(serviceDetail)))); // Service detail added
                                                                                }
                                                                                else
                                                                                {
                                                                                    sessions[id].Queue_command(Encoding.Unicode.GetBytes("0227")); // Service detail not updated
                                                                                }
                                                                            }
                                                                        }
                                                                        
                                                                    }
                                                                    else if (serviceDetail.idService.Length == 21)
                                                                    {
                                                                        using (SqlCommand command = new SqlCommand("update SERVICE_DETAIL set AmountOfService = @AmountOfService, TotalServicePrice = @TotalServicePrice, Note = @Note where idWedding = @idWedding and idService = @idService", sql))
                                                                        {
                                                                            command.Parameters.AddWithValue("@idWedding", serviceDetail.idWedding);
                                                                            command.Parameters.AddWithValue("@idService", serviceDetail.idService);
                                                                            command.Parameters.AddWithValue("@AmountOfService", serviceDetail.AmountOfService);
                                                                            command.Parameters.AddWithValue("@TotalServicePrice", serviceDetail.TotalServicePrice);
                                                                            command.Parameters.AddWithValue("@Note", serviceDetail.Note);
                                                                            if (command.ExecuteNonQuery() > 0)
                                                                            {
                                                                                sessions[id].Queue_command(Encoding.Unicode.GetBytes("0127" + Wrap_data_with_byte(Jil.JSON.Serialize<ServiceDetail>(serviceDetail)))); // Service detail updated
                                                                            }
                                                                            else
                                                                            {
                                                                                sessions[id].Queue_command(Encoding.Unicode.GetBytes("0227")); // Service detail not updated
                                                                            }
                                                                        }
                                                                    }
                                                                    else if (serviceDetail.idService.Length == 22 && serviceDetail.idService.StartsWith("-"))
                                                                    {
                                                                        string key = serviceDetail.idService.Substring(1, 2);
                                                                        long idl = long.Parse(serviceDetail.idService.Substring(3));
                                                                        if (key.Equals("SE") && check_existed_id(idl, key))
                                                                        {
                                                                            using (SqlCommand command = new SqlCommand("delete from SERVICE_DETAIL where idWedding = @idWedding and idService = @idService", sql))
                                                                            {
                                                                                command.Parameters.AddWithValue("@idWedding", serviceDetail.idWedding);
                                                                                command.Parameters.AddWithValue("@idService", serviceDetail.idService);
                                                                                if (command.ExecuteNonQuery() > 0)
                                                                                {
                                                                                    sessions[id].Queue_command(Encoding.Unicode.GetBytes("0427" + Wrap_data_with_byte(Jil.JSON.Serialize<ServiceDetail>(serviceDetail)))); // Service detail deleted
                                                                                }
                                                                                else
                                                                                {
                                                                                    sessions[id].Queue_command(Encoding.Unicode.GetBytes("0227")); // Service detail not deleted
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        sessions[id].Queue_command(Encoding.Unicode.GetBytes("0227")); // Service detail not updated
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                    else throw new Exception("Invalid idWedding");
                                                }
                                            }
                                        }
                                        catch (Exception) { sessions[id].Queue_command(Encoding.Unicode.GetBytes("0227")); }
                                    }
                                    break;

                                // get list of bills
                                case "0028":
                                    {
                                        List<Bill> bills = new List<Bill>();
                                        using (var sql = new SqlConnection(sqlConnectionString))
                                        {
                                            sql.Open();
                                            using (SqlCommand command = new SqlCommand("select * from BILL", sql))
                                            {
                                                using (SqlDataReader reader = command.ExecuteReader())
                                                {
                                                    while (reader.Read())
                                                    {
                                                        bills.Add(new Bill(reader["idBill"].ToString(), (DateTime)reader["InvoiceDate"], (long)reader["TablePricetotal"], (long)reader["ServicePriceTotal"], (long)reader["Total"], (DateTime)reader["PaymentDate"], (long)reader["MoneyLeft"]));
                                                    }
                                                }
                                            }
                                        }
                                        sessions[id].Queue_command(Combine(Encoding.Unicode.GetBytes("0028"),
                                            Encoding.Unicode.GetBytes(Wrap_data_with_byte(Jil.JSON.Serialize(bills)))));
                                    }
                                    break;

                                default:
                                    shutdown(id);
                                    Console.WriteLine("Received strange signal, socket closed");
                                    break;
                            }
                        }
                        else
                        {
                            shutdown(id);
                            Console.WriteLine("Received strange signal, socket closed (2)");
                        }
                        //sessions[id].stream = s;
                        Console.WriteLine("Work finished");
                    }
                    else
                    {
                        shutdown(id);
                        Console.WriteLine("Received strange signal, socket closed (3)");
                    }
                } while (sessions[id].client.Available > 0);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.WriteLine("Work quitted");
                try
                {
                    exception_handler(new KeyValuePair<string, Client>(id, sessions[id]), e.ToString());
                }
                catch (Exception xe)
                {
                    Console.WriteLine(xe.ToString());
                }
            }
            finally
            {
                try
                {
                    if (sessions.ContainsKey(id))
                        Interlocked.Exchange(ref sessions[id].is_locked, 0);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        private static void exception_handler(KeyValuePair<string, Client> item, string se)
        {
            try
            {
                if (se.Contains("open and available Connection"))
                {
                    //sql.Open();
                }
                else if (se.Contains("Execution Timeout Expired"))
                {
                    //sql.Open();
                }
                else if (se.Contains("was forcibly closed"))
                {
                    shutdown(item.Key);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        internal static void shutdown(string id)
        {
            Console.WriteLine("{0} has quit", id);
            try
            {
                sessions[id].stream.Dispose();
            }
            catch (Exception )
            {

            }
            try
            {
                sessions[id].client.Dispose();
            }
            catch (Exception )
            {

            }
            sessions.TryRemove(id, out Client temp);
        }

        private static bool check_existed_username(string v)
        {
            string commandtext = "select top 1 id from ACCOUNTS where username=@username";
            using (SqlConnection sql = new SqlConnection(sqlConnectionString))
            {
                sql.Open();
                using (SqlCommand command = new SqlCommand(commandtext, sql))
                {
                    command.Parameters.AddWithValue("@username", v);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return true;
                        }
                        else return false;
                    }
                }
            }
        }

        internal static long GetNewACCOUNTSId()
        {
            Int64 randomid = 0;
            while (randomid <= 0 || check_existed_id(randomid))
            {
                randomid = NextInt64(rand);
            }
            return randomid;
        }

        internal static long GetNewIdFromTable(string tableKey)
        {
            if (tableKey.Length > 2) throw new Exception("Table key is too long");
            Int64 randomid = 0;
            while (randomid <= 0 || check_existed_id(randomid, tableKey))
            {
                randomid = NextInt64(rand);
            }
            return randomid;
        }

        private static bool check_existed_id(long randomid, string key)
        {
            if (randomid > 0)
            {
                switch (key)
                {
                    case "LT":
                        {
                            string idStr = key + randomid.ToString();
                            return check_existed_id("LOBBY_TYPE", "idLobbyType", idStr);
                        }
                    case "LO":
                        {
                            string idStr = key + randomid.ToString();
                            return check_existed_id("LOBBY", "idLobby", idStr);
                        }
                    case "SH":
                        {
                            string idStr = key + randomid.ToString();
                            return check_existed_id("SHIFT", "idShift", idStr);
                        }
                    case "WD":
                        {
                            string idStr = key + randomid.ToString();
                            return check_existed_id("WEDDING_INFOR", "idWedding", idStr);
                        }
                    case "MN":
                        {
                            string idStr = key + randomid.ToString();
                            return check_existed_id("MENU", "idDishes", idStr);
                        }
                    case "SV":
                        {
                            string idStr = key + randomid.ToString();
                            return check_existed_id("SERVICE", "idService", idStr);
                        }
                    case "BI":
                        {
                            string idStr = key + randomid.ToString();
                            return check_existed_id("BILL", "idBill", idStr);
                        }
                    case "RR":
                        {
                            string idStr = key + randomid.ToString();
                            return check_existed_id("REVENUE_REPORT", "idReport", idStr);
                        }
                    case "PA":
                        {
                            string idStr = key + randomid.ToString();
                            return check_existed_id("PARAMETER", "idParameter", idStr);
                        }
                    default:
                        throw new Exception("Unknown table key");
                }
            }
            else
            {
                return true;
            }
        }

        private static bool check_existed_id(string table, string idColumn, string key)
        {
            string commandtext = "select top 1 id from " + table + " where " + idColumn +"=@id";
            using (SqlConnection sql = new SqlConnection(sqlConnectionString))
            {
                sql.Open();
                using (SqlCommand command = new SqlCommand(commandtext, sql))
                {
                    command.Parameters.AddWithValue("@id", key);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return true;
                        }
                        else return false;
                    }
                }
            }
        }

        private static bool check_existed_id(long randomid)
        {
            if (randomid > 0)
            {
                string commandtext = "select top 1 id from ACCOUNTS where id=@id";
                using (SqlConnection sql = new SqlConnection(sqlConnectionString))
                {
                    sql.Open();
                    using (SqlCommand command = new SqlCommand(commandtext, sql))
                    {
                        command.Parameters.AddWithValue("@id", randomid);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return true;
                            }
                            else return false;
                        }
                    }
                }
            }
            return true;
        }
    }
}
