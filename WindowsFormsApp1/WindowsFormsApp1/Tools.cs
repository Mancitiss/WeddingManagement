using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class Tools
    {
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

        internal static string data_with_byte(string data)
        {
            if (!string.IsNullOrEmpty(data))
            {
                string databyte = Encoding.Unicode.GetByteCount(data).ToString();
                return databyte.Length.ToString().PadLeft(2, '0') + databyte + data;
            }
            return "";
        }

        internal static string data_with_ASCII_byte(string data)
        {
            if (!string.IsNullOrEmpty(data))
            {
                string databyte = Encoding.ASCII.GetByteCount(data).ToString();
                return databyte.Length.ToString().PadLeft(2, '0') + databyte + data;
            }
            return "";
        }

        internal static bool receive_data_automatically(SslStream stream, out string data)
        {
            if (Stream_receive(stream, 4, out data))
            {
                if (Int32.TryParse(data, out int bytesize))
                {
                    bytesize = bytesize * 2;
                    if (Stream_receive(stream, bytesize, out data))
                    {
                        if (Int32.TryParse(data, out bytesize))
                        {
                            if (Stream_receive(stream, bytesize, out data))
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

        internal static bool receive_ASCII_data_automatically(SslStream stream, out string data)
        {
            if (Stream_receive_ASCII(stream, 2, out data))
            {
                if (Int32.TryParse(data, out int bytesize))
                {
                    if (Stream_receive_ASCII(stream, bytesize, out data))
                    {
                        if (Int32.TryParse(data, out bytesize))
                        {
                            if (Stream_receive_ASCII(stream, bytesize, out data))
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

        internal static bool Stream_receive(SslStream stream, int byte_expected, out string data_string)
        {
            try
            {
                int total_byte_received = 0;
                byte[] data = new byte[byte_expected];
                int received_byte;
                Console.WriteLine("Expected: {0}", byte_expected);
                do
                {
                    received_byte = stream.Read(data, total_byte_received, byte_expected);
                    if (received_byte > 0)
                    {
                        total_byte_received += received_byte;
                        byte_expected -= received_byte;
                    }
                    else break;
                } while (byte_expected > 0 && received_byte > 0);
                Console.WriteLine("Received: {0}", total_byte_received);
                if (byte_expected == 0) // all data received
                {
                    data_string = Encoding.Unicode.GetString(data, 0, total_byte_received);
                    return true;
                }
                else // data corrupted
                {
                    data_string = "";

                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw e;
            }
        }

        internal static bool Stream_receive_ASCII(SslStream stream, int byte_expected, out string data_string)
        {
            int total_byte_received = 0;
            byte[] data = new byte[byte_expected];
            int received_byte;
            Console.WriteLine("Expected: {0}", byte_expected);
            do
            {
                received_byte = stream.Read(data, total_byte_received, byte_expected);
                if (received_byte > 0)
                {
                    total_byte_received += received_byte;
                    byte_expected -= received_byte;
                }
                else break;
            } while (byte_expected > 0 && received_byte > 0);
            Console.WriteLine("Received: {0}", total_byte_received);
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

        public static string ImageToString(string path)
        {
            if (path == null)
                throw new ArgumentNullException("path");
            Image im = Image.FromFile(path);
            MemoryStream ms = new MemoryStream();
            im.Save(ms, im.RawFormat);
            byte[] array = ms.ToArray();
            return Convert.ToBase64String(array);
        }
        public static Image StringToImage(string imageString)
        {

            if (imageString == null)
                throw new ArgumentNullException("imageString");
            byte[] array = Convert.FromBase64String(imageString);
            Image image = Image.FromStream(new MemoryStream(array));
            return image;
        }

        internal static bool SslStream_receive_bytes(SslStream stream, int byte_expected, out byte[] data)
        {
            int total_byte_received = 0;
            data = new byte[byte_expected];
            int received_byte;
            do
            {
                received_byte = stream.Read(data, total_byte_received, byte_expected);
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
    }
}
