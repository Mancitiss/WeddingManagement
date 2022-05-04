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
                    }
                    else
                    if (instruction == "0010") // 0010 = log in
                    {
                        Receive_data_automatically(sslStream, out string json);
                        Account act = Jil.JSON.Deserialize<Account>(json);
                        try
                        {
                            string commandtext = "select top 1 id, name, pw, priority from account where username=@username";
                            using (SqlConnection sql = new SqlConnection(sqlConnectionString))
                            {
                                sql.Open();
                                using (SqlCommand command = new SqlCommand(commandtext, sql))
                                {
                                    command.Parameters.AddWithValue("@username", act.username);
                                    using (SqlDataReader reader = command.ExecuteReader())
                                    {
                                        Console.WriteLine("After avatar");
                                        if (reader.Read())
                                        {
                                            //if (act.pw == reader["pw"].ToString())
                                            if (act.pw == reader["pw"].ToString() || Crypter.CheckPassword(act.pw, reader["pw"].ToString()))
                                            {
                                                bool skip = false;
                                                if (act.pw == reader["pw"].ToString())
                                                {
                                                    using (SqlCommand changepass = new SqlCommand("update top (1) account set pw = @pw where id = @id", sql))
                                                    {
                                                        changepass.Parameters.AddWithValue("@pw", Crypter.Blowfish.Crypt(act.pw));
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

                                                    sslStream.Write(Encoding.Unicode.GetBytes("0200" + id));
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
                                        } // log-in failed account doesn't exist
                                    }
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.ToString());
                        }
                    }
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
                                // create new account (only recruiters and admins can do this)
                                case "0011":
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
                                                        using (SqlCommand command = new SqlCommand("insert into account values (@id, @username, @pw, @priority)", sql))
                                                        {
                                                            command.Parameters.AddWithValue("@id", id_string);
                                                            command.Parameters.AddWithValue("@username", act.username);
                                                            command.Parameters.AddWithValue("@pw", Crypter.Blowfish.Crypt(act.pw));
                                                            command.Parameters.AddWithValue("@priority", act.priority);
                                                            command.ExecuteNonQuery();
                                                        }
                                                        sessions[id].Queue_command(Encoding.Unicode.GetBytes("1011")); // New account created
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


                                // promote/demote account (only recruiters and admins can do this)
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
                                                        using (SqlCommand command = new SqlCommand("select priority from account where id = @id", sql))
                                                        {
                                                            command.Parameters.AddWithValue("@id", act.id);
                                                            currentPriority = (Int16)command.ExecuteScalar();
                                                        }
                                                    }
                                                }
                                                else if (act.username != null)
                                                {
                                                    using (SqlCommand command = new SqlCommand("select priority from account where username = @username", sql))
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
                                                    using (SqlCommand command = new SqlCommand("update account set priority = @priority where username = @username", sql))
                                                    {
                                                        command.Parameters.AddWithValue("@username", act.username);
                                                        command.Parameters.AddWithValue("@priority", act.priority);
                                                        command.ExecuteNonQuery();
                                                    }
                                                    sessions[id].Queue_command(Encoding.Unicode.GetBytes("2111")); // Account promoted/demoted
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
                                case "0020":
                                    {
                                        List<LobbyType> lobbyTypes = new List<LobbyType>();
                                        using (var sql = new SqlConnection(sqlConnectionString))
                                        {
                                            sql.Open();
                                            using (SqlCommand command = new SqlCommand("select * from LOBBYTYPE", sql))
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

                                // get list of lobbies
                                case "0021":
                                    {
                                        List<Lobby> lobbies = new List<Lobby>();
                                        using (var sql = new SqlConnection(sqlConnectionString))
                                        {
                                            sql.Open();
                                            using (SqlCommand command = new SqlCommand("select * from LOBBY", sql))
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

                                // get list of shifts
                                case "0022":
                                    {
                                        List<Shift> shifts = new List<Shift>();
                                        using (var sql = new SqlConnection(sqlConnectionString))
                                        {
                                            sql.Open();
                                            using (SqlCommand command = new SqlCommand("select * from SHIFT", sql))
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

                                // get list of weddings
                                case "0023":
                                    {
                                        List<WeddingInfo> weddings = new List<WeddingInfo>();
                                        using (var sql = new SqlConnection(sqlConnectionString))
                                        {
                                            sql.Open();
                                            using (SqlCommand command = new SqlCommand("select * from WEDDING", sql))
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

                                // get list of menus
                                case "0024":
                                    {
                                        List<Menu> menus = new List<Menu>();
                                        using (var sql = new SqlConnection(sqlConnectionString))
                                        {
                                            sql.Open();
                                            using (SqlCommand command = new SqlCommand("select * from MENU", sql))
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

                                // get list of services
                                case "0025":
                                    {
                                        List<Service> services = new List<Service>();
                                        using (var sql = new SqlConnection(sqlConnectionString))
                                        {
                                            sql.Open();
                                            using (SqlCommand command = new SqlCommand("select * from SERVICE", sql))
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

                                // get lish of Table Details
                                case "0026":
                                    {
                                    List<TableDetail> tableDetails = new List<TableDetail>();
                                    using (var sql = new SqlConnection(sqlConnectionString))
                                    {
                                            sql.Open();
                                            using (SqlCommand command = new SqlCommand("select * from TABLE_DETAIL", sql))
                                            {
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
                        return true;
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
