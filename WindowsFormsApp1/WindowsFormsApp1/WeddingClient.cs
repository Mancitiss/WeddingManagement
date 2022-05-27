using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static WindowsFormsApp1.Tools;

namespace WindowsFormsApp1
{
    internal class WeddingClient
    {
        private static string instruction;

        internal static TcpClient client;
        internal static SslStream stream;
        internal static Account user;

        internal static bool loginResult = true; // set this back to true after use

        static string currentID = null;

        private static int workeradded = 0;

        internal static ConcurrentQueue<byte[]> commands = new ConcurrentQueue<byte[]>();

        public static void ExecuteClient()
        {
            try
            {
                while (user != null && client!= null && client.Connected)
                {
                    //Console.WriteLine("In loop");
                    try
                    {
                        Receive_from_id(client);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                Logout();
            }
        }

        private static void Receive_from_id(TcpClient self)
        {
            try
            {
                if (Stream_receive(stream, 8, out string data))
                {
                    instruction = data;
                    Console.WriteLine(data);
                    switch (instruction)
                    {
                        case "-200": // -200 = logged in failed
                            {
                                Console.WriteLine("Thong tin dang nhap bi sai");
                                loginResult = false;
                            } // logged in failed
                            break;
                        case "0200": // logged in successfully
                            { // 0200 = logged in successfully
                                if (receive_data_automatically(stream, out data))
                                {
                                    user = Jil.JSON.Deserialize<Account>(data);
                                    Console.WriteLine(user.id);
                                    Console.WriteLine(user.priority);
                                }
                            } // successfully logged in
                            break;
                        case "1011": // 1011 = New account created successfully
                            {
                                Console.WriteLine("New account created");
                            } // New account created successfully
                            break;
                        case "1111": // 1111 = Username exists
                            {
                                Console.WriteLine("This username is already in use");
                            } // username is already in use
                            break;
                        case "2004": // 2004 = log in from another device
                            {
                                Console.WriteLine("You are logged in from another device, you will be logged out");

                                // invoke show login form and log out current user like below
                                //Program.mainform.Invoke(Program.mainform.show_login_delegate);

                            } // logged in from another device, will log out
                            break;
                        case "2111":
                            {
                                // account promoted/demoted successfully
                            }
                            break;
                        case "3111":
                            {
                                // account promoted/demoted failed, you may not have permission
                            }
                            break;
                        case "4269": // password changed successfully
                            {
                                Console.WriteLine("Password changed successfully!");

                                // invoke "change password successfully" delegate like below
                                //Program.mainform.formSettings.Invoke(Program.mainform.formSettings.changeSettingsWarning, new object[] { "Password changed successfully!", Color.FromArgb(143, 228, 185) });
                            } // successfully changed password
                            break;
                        case "9624": // old password is incorrect
                            {
                                Console.WriteLine("Old Password is not correct!!");

                                // invoke "old password is incorrect" delegate like below
                                //Program.mainform.formSettings.Invoke(Program.mainform.formSettings.changeSettingsWarning, new object[] { "Current password is incorrect!", Color.FromArgb(213, 54, 41) });

                            } // password is incorrect
                            break;



                        // app management commands

                        // get lobby types
                        case "0020":
                            {
                                if (receive_data_automatically(stream, out data))
                                {
                                    List<LobbyType> lobbyTypes = Jil.JSON.Deserialize<List<LobbyType>>(data);
                                    // do whatever you want to do with the data here

                                }
                            }
                            break;

                        // update lobby type successfully
                        case "0120":
                            {
                                if (receive_data_automatically(stream, out string json))
                                {
                                    LobbyType lobbyType = Jil.JSON.Deserialize<LobbyType>(json);
                                    // inform user that lobby type has been updated and update lobby type list
                                }

                            }
                            break;

                        // update lobby type failed
                        // don't update the last lobby type change 
                        // don't add the on waiting lobby type to the list
                        case "0220":
                            {
                                // inform user that lobby type has not been updated
                            }
                            break;

                        // lobby type added, get ID
                        case "0320":
                            {
                                if (receive_data_automatically(stream, out data))
                                {
                                    LobbyType lobbyType = Jil.JSON.Deserialize<LobbyType>(data);
                                    // add lobby type to list
                                }
                            }
                            break;

                        // lobby type deleted
                        case "0420":
                            {
                                if (receive_data_automatically(stream, out data))
                                {
                                    LobbyType lobbyType = Jil.JSON.Deserialize<LobbyType>(data);
                                    // remove lobby type from list if it exists and equals to this lobbytype object
                                }

                            }
                            break;

                        // get list of lobbies
                        case "0021":
                            {
                                if (receive_data_automatically(stream, out string json))
                                {
                                    List<Lobby> lobbies = Jil.JSON.Deserialize<List<Lobby>>(json);
                                    // do whatever you want to do with the data here

                                }
                            }
                            break;

                        // update lobby successfully
                        case "0121":
                            {
                                if (receive_data_automatically(stream, out string json))
                                {
                                    Lobby lobby = Jil.JSON.Deserialize<Lobby>(json);
                                    // inform user that lobby has been updated and update lobby list
                                }
                            }
                            break;

                        // update lobby failed
                        // don't update the last lobby change
                        // don't add the on waiting lobby to the list
                        case "0221":
                            {
                                // inform user that lobby has not been updated
                            }
                            break;

                        // lobby added, get ID
                        case "0321":
                            {
                                if (receive_data_automatically(stream, out string json))
                                {
                                    Lobby lobby = Jil.JSON.Deserialize<Lobby>(json);
                                    // add lobby to list
                                }
                            }
                            break;

                        // lobby deleted
                        case "0421":
                            {
                                if (receive_data_automatically(stream, out string json))
                                {
                                    Lobby lobby = Jil.JSON.Deserialize<Lobby>(json);
                                    // remove lobby from list if it exists and equals to this lobby object
                                }
                            }
                            break;

                        // get list of shifts
                        case "0022":
                            {
                                if (receive_data_automatically(stream, out string json))
                                {
                                    List<Shift> shifts = Jil.JSON.Deserialize<List<Shift>>(json);
                                    // do whatever you want to do with the data here

                                }
                            }
                            break;

                        // update shift successfully
                        case "0122":
                            {
                                if (receive_data_automatically(stream, out string json))
                                {
                                    Shift shift = Jil.JSON.Deserialize<Shift>(json);
                                    // inform user that shift has been updated and update shift list
                                }
                            }
                            break;

                        // update shift failed
                        case "0222":
                            {
                                // inform user that shift has not been updated
                                
                            }
                            break;

                        // shift added, get ID
                        case "0322":
                            {
                                if (receive_data_automatically(stream, out string json))
                                {
                                    Shift shift = Jil.JSON.Deserialize<Shift>(json);
                                    // add shift to list
                                }
                            }
                            break;

                        // shift deleted
                        case "0422":
                            {
                                if (receive_data_automatically(stream, out string json))
                                {
                                    Shift shift = Jil.JSON.Deserialize<Shift>(json);
                                    // remove shift from list if it exists and equals to this shift object
                                }
                            }
                            break;

                        // get list of weddings
                        case "0023":
                            {
                                if (receive_data_automatically(stream, out string json))
                                {
                                    List<WeddingInfo> weddings = Jil.JSON.Deserialize<List<WeddingInfo>>(json);
                                    // do whatever you want to do with the data here

                                }
                            }
                            break;

                        // update wedding successfully
                        case "0123":
                            {
                                if (receive_data_automatically(stream, out string json))
                                {
                                    WeddingInfo wedding = Jil.JSON.Deserialize<WeddingInfo>(json);
                                    // inform user that wedding has been updated and update wedding list
                                }
                            }
                            break;

                        // update wedding failed
                        case "0223":
                            {
                                // inform user that wedding has not been updated
                            }
                            break;

                        // wedding added, get ID
                        case "0323":
                            {
                                if (receive_data_automatically(stream, out string json))
                                {
                                    WeddingInfo wedding = Jil.JSON.Deserialize<WeddingInfo>(json);
                                    // add wedding to list
                                }
                            }
                            break;
                        // wedding canceled
                        case "0423":
                            {
                                if (receive_data_automatically(stream, out string json))
                                {
                                    WeddingInfo wedding = Jil.JSON.Deserialize<WeddingInfo>(json);
                                    // remove wedding from list if it exists and equals to this wedding object
                                }
                            }
                            break;

                        // get menus
                        case "0024":
                            {
                                if (receive_data_automatically(stream, out string json))
                                {
                                    List<Menu> menus = Jil.JSON.Deserialize<List<Menu>>(json);
                                    (Program.mainform.GetCurrentChildForm() as FormDishes).Invoke((Program.mainform.GetCurrentChildForm() as FormDishes).AddMenuDelegate, new object[] { menus });

                                }
                            }
                            break;

                        // update menu successfully
                        case "0124":
                            {
                                if (receive_data_automatically(stream, out string json))
                                {
                                    Menu menu = Jil.JSON.Deserialize<Menu>(json);
                                    // inform user that menu has been updated and update menu list
                                    //listOfMenu[listOfMenu.IndexOf(menu)]=menu;
                                }
                            }
                            break;

                        // update menu failed
                        case "0224":
                            {
                                // inform user that menu has not been updated
                            }
                            break;

                        // menu added, get ID
                        case "0324":
                            {
                                if (receive_data_automatically(stream, out string json))
                                {
                                    Menu menu = Jil.JSON.Deserialize<Menu>(json);
                                    //listOfMenu.Add(menu);
                                }
                            }
                            break;

                        // menu deleted
                        case "0424":
                            {
                                if (receive_data_automatically(stream, out string json))
                                {
                                    Menu menu = Jil.JSON.Deserialize<Menu>(json);
                                    // remove menu from list if it exists and equals to this menu object
                                    //listOfMenu.Remove(menu);
                                }
                            }
                            break;

                        // get list of services
                        case "0025":
                            {
                                if (receive_data_automatically(stream, out string json))
                                {
                                    List<Service> services = Jil.JSON.Deserialize<List<Service>>(json);
                                    // do whatever you want to do with the data here

                                }
                            }
                            break;

                        // update service successfully
                        case "0125":
                            {
                                if (receive_data_automatically(stream, out string json))
                                {
                                    Service service = Jil.JSON.Deserialize<Service>(json);
                                    // inform user that service has been updated and update service list
                                }
                            }
                            break;

                        // update service failed
                        case "0225":
                            {
                                // inform user that service has not been updated
                            }
                            break;

                        // service added, get ID
                        case "0325":
                            {
                                if (receive_data_automatically(stream, out string json))
                                {
                                    Service service = Jil.JSON.Deserialize<Service>(json);
                                    // add service to list
                                }
                            }
                            break;

                        // service deleted
                        case "0425":
                            {
                                if (receive_data_automatically(stream, out string json))
                                {
                                    Service service = Jil.JSON.Deserialize<Service>(json);
                                    // remove service from list if it exists and equals to this service object
                                }
                            }
                            break;
                            

                        case "0026":
                            {
                                if (receive_data_automatically(stream, out string json))
                                {
                                    List<TableDetail> tableDetails = Jil.JSON.Deserialize<List<TableDetail>>(json);
                                    // do whatever you want to do with the data here

                                }
                            }
                            break;

                        // update table successfully
                        case "0126":
                            {
                                if (receive_data_automatically(stream, out string json))
                                {
                                    TableDetail tableDetail = Jil.JSON.Deserialize<TableDetail>(json);
                                    // inform user that table has been updated and update table list
                                }
                            }
                            break;

                        // update table failed
                        case "0226":
                            {
                                // inform user that table has not been updated
                            }
                            break;

                        // table added, get ID
                        case "0326":
                            {
                                if (receive_data_automatically(stream, out string json))
                                {
                                    TableDetail tableDetail = Jil.JSON.Deserialize<TableDetail>(json);
                                    // add table to list
                                }
                            }
                            break;

                        // table deleted
                        case "0426":
                            {
                                if (receive_data_automatically(stream, out string json))
                                {
                                    TableDetail tableDetail = Jil.JSON.Deserialize<TableDetail>(json);
                                    // remove table from list if it exists and equals to this table object
                                }
                            }
                            break;
                            
                            // get service detail
                        case "0027":
                            {
                                if (receive_data_automatically(stream, out string json))
                                {
                                    List<ServiceDetail> serviceDetails = Jil.JSON.Deserialize<List<ServiceDetail>>(json);
                                    // do whatever you want to do with the data here

                                }
                            }
                            break;

                        // update service detail successfully
                        case "0127":
                            {
                                if (receive_data_automatically(stream, out string json))
                                {
                                    ServiceDetail serviceDetail = Jil.JSON.Deserialize<ServiceDetail>(json);
                                    // inform user that service detail has been updated and update service detail list
                                }
                            }
                            break;

                        // update service detail failed
                        case "0227":
                            {
                                // inform user that service detail has not been updated
                            }
                            break;

                        // service detail added, get ID
                        case "0327":
                            {
                                if (receive_data_automatically(stream, out string json))
                                {
                                    ServiceDetail serviceDetail = Jil.JSON.Deserialize<ServiceDetail>(json);
                                    // add service detail to list
                                }
                            }
                            break;

                        // service detail deleted
                        case "0427":
                            {
                                if (receive_data_automatically(stream, out string json))
                                {
                                    ServiceDetail serviceDetail = Jil.JSON.Deserialize<ServiceDetail>(json);
                                    // remove service detail from list if it exists and equals to this service detail object
                                }
                            }
                            break;
                            
                            

                        default:
                            {
                                
                            }
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public static bool Logged_in(string tk, string mk)
        {
            string server_address = ConfigurationManager.AppSettings.Get("sever_address");
            client = new TcpClient(server_address, Convert.ToInt16(ConfigurationManager.AppSettings.Get("port")));
            stream = new SslStream(
                client.GetStream(),
                false,
                new RemoteCertificateValidationCallback(ValidateServerCertificate),
                null
                );
            try
            {
                stream.AuthenticateAsClient(server_address);
            }
            catch (AuthenticationException e)
            {
                Console.WriteLine("Exception: {0}", e.Message);
                if (e.InnerException != null)
                {
                    Console.WriteLine("Inner exception: {0}", e.InnerException.Message);
                }
                Console.WriteLine("Authentication failed - closing the connection.");
                stream.Close();
                client.Close();
                return false;
            }
            try
            {
                Queue_command(Encoding.Unicode.GetBytes("0010" + data_with_byte(tk) + data_with_byte(mk))); //0010 = log in
                Receive_from_id(client);
                if (user == null)
                {
                    Queue_command(Encoding.Unicode.GetBytes("2004")); // 2004 = stop client
                    Ping();
                    stream.Close();
                    client.Close();
                    return false;
                }
                currentID = user.id;
                if (!loginResult)
                {
                    return false;
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
            }
        }
        
        internal static void Ping()
        {
            try
            {
                string server_address = ConfigurationManager.AppSettings.Get("sever_address");
                using (var client_2 = new TcpClient(server_address, Convert.ToInt16(ConfigurationManager.AppSettings.Get("port"))))
                {
                    using (var stream_2 = new SslStream(
                        client_2.GetStream(),
                        false,
                        new RemoteCertificateValidationCallback(ValidateServerCertificate),
                        null
                        ))
                    {
                        try
                        {
                            stream_2.AuthenticateAsClient(server_address);
                        }
                        catch (AuthenticationException e)
                        {
                            Console.WriteLine("Exception: {0}", e.Message);
                            if (e.InnerException != null)
                            {
                                Console.WriteLine("Inner exception: {0}", e.InnerException.Message);
                            }
                            Console.WriteLine("Authentication failed - closing the connection.");
                            stream_2.Close();
                            client_2.Close();
                        }
                        stream_2.Write(Combine(Encoding.Unicode.GetBytes("0012"), Encoding.ASCII.GetBytes(user.id)));
                        Console.WriteLine("Pinged");
                    }
                }
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.ToString());
            }
        }

        private static void Logout()
        {
            //Ping();
            user = null;
            commands = new ConcurrentQueue<byte[]>();
            stream.Dispose();
            client.Dispose();
            GC.Collect();
        }

        internal static void Queue_command(byte[] command)
        {
            commands.Enqueue(command);
            Ping();
            Add_worker_thread();
        }

        private static void Add_worker_thread()
        {
            Console.WriteLine("worker: {0}", workeradded);
            if (0 == Interlocked.Exchange(ref workeradded, 1))
            {
                try
                {
                    ThreadPool.QueueUserWorkItem(Send_commands);
                }
                catch (NotSupportedException nse)
                {
                    Console.WriteLine(nse.ToString());
                    try
                    {
                        Interlocked.Exchange(ref workeradded, 0);
                    }
                    catch { }
                }
            }
        }

        private static void Send_commands(object state)
        {
            Console.WriteLine("start sending command");
            try
            {
                while (!commands.IsEmpty)
                    if (commands.TryDequeue(out byte[] command))
                    {
                        Console.WriteLine("Sending command...");
                        stream.Write(command);
                        Console.WriteLine("Command sent");
                        Ping();
                    }
                Ping();
                Interlocked.Exchange(ref workeradded, 0);
                Console.WriteLine("Worker reset!");
            }
            catch (Exception se)
            {
                Console.WriteLine(se.ToString());
                //throw se;
            }
        }

        public static bool ValidateServerCertificate(
             object sender,
             X509Certificate certificate,
             X509Chain chain,
             SslPolicyErrors sslPolicyErrors)
        {
            if (sslPolicyErrors == SslPolicyErrors.None)
                return true;

            Console.WriteLine("Certificate error: {0}", sslPolicyErrors);

            // Do not allow this client to communicate with unauthenticated servers.
            return false;
        }        
    }
}
