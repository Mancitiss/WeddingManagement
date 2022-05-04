using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace WeddingManagementServer
{
    internal class Tools
    {
        internal static bool Receive_ASCII_data_automatically(SslStream s, out string data)
        {
            if (SslStream_receive_ASCII(s, 2, out data))
            {
                int bytesize;
                if (Int32.TryParse(data, out bytesize))
                {
                    if (SslStream_receive_ASCII(s, bytesize, out data))
                    {
                        if (Int32.TryParse(data, out bytesize))
                        {
                            if (SslStream_receive_ASCII(s, bytesize, out data))
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            data = "";
            return false;
        }

        internal static bool Receive_data_automatically(SslStream s, out string data)
        {
            if (SslStream_receive(s, 4, out data))
            {
                //Console.WriteLine("1:"+data);
                int bytesize;
                if (Int32.TryParse(data, out bytesize))
                {
                    bytesize = bytesize * 2;
                    if (SslStream_receive(s, bytesize, out data))
                    {
                        //Console.WriteLine("2:" + data);
                        if (Int32.TryParse(data, out bytesize))
                        {
                            if (SslStream_receive(s, bytesize, out data))
                            {
                                //Console.WriteLine("3:" + data);
                                return true;
                            }
                        }
                    }
                }
            }
            //Console.WriteLine("wrong data: " + data);
            data = "";
            return false;
        }

        internal static bool SslStream_receive_bytes(SslStream s, int byte_expected, out byte[] data)
        {
            int total_byte_received = 0;
            data = new byte[byte_expected];
            int received_byte;
            do
            {
                received_byte = s.Read(data, total_byte_received, byte_expected);
                if (received_byte > 0)
                {
                    total_byte_received += received_byte;
                    byte_expected -= received_byte;
                }
                else break;
            } while (byte_expected > 0 && received_byte > 0);
            if (byte_expected == 0) // all data received
            {
                return true;
            }
            else // data corrupted
            {
                return false;
            }
        }

        internal static bool SslStream_receive_ASCII(SslStream s, int byte_expected, out string data_string)
        {
            int total_byte_received = 0;
            byte[] data = new byte[byte_expected];
            int received_byte;
            do
            {
                received_byte = s.Read(data, total_byte_received, byte_expected);
                if (received_byte > 0)
                {
                    total_byte_received += received_byte;
                    byte_expected -= received_byte;
                }
                else break;
            } while (byte_expected > 0 && received_byte > 0);
            if (byte_expected == 0) // all data received
            {
                data_string = Encoding.ASCII.GetString(data, 0, total_byte_received);
                return true;
            }
            else // data corrupted
            {
                data_string = "";
                return false;
            }
        }

        internal static bool SslStream_receive(SslStream s, int byte_expected, out string data_string)
        {
            int total_byte_received = 0;
            byte[] data = new byte[byte_expected];
            int received_byte;
            do
            {
                received_byte = s.Read(data, total_byte_received, byte_expected);
                if (received_byte > 0)
                {
                    total_byte_received += received_byte;
                    byte_expected -= received_byte;
                }
                else break;
            } while (byte_expected > 0 && received_byte > 0);
            if (byte_expected == 0) // all data received
            {
                data_string = Encoding.Unicode.GetString(data, 0, total_byte_received);
                return true;
            }
            else // data corrupted
            {
                //Console.WriteLine("Corrupted: " + Encoding.Unicode.GetString(data, 0, total_byte_received));
                data_string = "";
                return false;
            }
        }

        internal static string Wrap_data_with_byte(string data)
        {
            if (!string.IsNullOrEmpty(data))
            {
                string databyte = Encoding.Unicode.GetByteCount(data).ToString();
                return databyte.Length.ToString().PadLeft(2, '0') + databyte + data;
            }
            return "";
        }

        internal static string Wrap_data_with_ASCII_byte(string data)
        {
            if (!string.IsNullOrEmpty(data))
            {
                string databyte = Encoding.ASCII.GetByteCount(data).ToString();
                return databyte.Length.ToString().PadLeft(2, '0') + databyte + data;
            }
            return "";
        }
        
        internal static byte[] Combine(params byte[][] arrays)
        {
            byte[] rv = new byte[arrays.Sum(a => a.Length)];
            int offset = 0;
            foreach (byte[] array in arrays)
            {
                System.Buffer.BlockCopy(array, 0, rv, offset, array.Length);
                offset += array.Length;
            }
            return rv;
        }

        internal static Int64 NextInt64(Random rnd)
        {
            var buffer = new byte[sizeof(Int64)];
            rnd.NextBytes(buffer);
            return BitConverter.ToInt64(buffer, 0);
        }
    }
}
