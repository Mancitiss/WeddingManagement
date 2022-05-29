using CryptSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeddingManagementApplication
{
    internal class WeddingClient
    {
        public static string client_id;
        public static short client_priority;
        public static bool Logged_in(string tk, string mk)
        {
            string commandtext = "select top 1 id, pw, priority from ACCOUNTS where username=@username";
            using (SqlConnection sql = new SqlConnection(ConfigurationManager.AppSettings.Get("conString")))
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
                                        skip = true;
                                        return false;
                                    }
                                }
                                if (!skip)
                                {
                                    string id = reader["id"].ToString();
                                    string str_id = id;
                                    while (id.Length < 19) id = '0' + id;
                                    client_id = id;
                                    client_priority = (short)reader["priority"];
                                    return true;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Wrong password");
                                return false;
                            } // wrong password

                        }
                        else
                        {
                            MessageBox.Show("Wrong username");
                            return false;
                        } // wrong username
                    } 
                }
                MessageBox.Show("Cannot connect to Database");
                return false;
            }
        }
    }
}
