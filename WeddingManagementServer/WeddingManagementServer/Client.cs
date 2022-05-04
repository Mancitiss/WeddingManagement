﻿using System;
using System.Collections.Concurrent;
using System.Net.Security;
using System.Net.Sockets;
using System.Threading;

namespace WeddingManagementServer
{
    internal class Client
    {
        internal TcpClient client;
        internal SslStream stream;
        internal string id;
        internal Int16 priority;
        internal int is_locked;
        internal int is_waited;
        internal ConcurrentQueue<byte[]> commands;
        private Int32 workeradded;

        internal Client()
        {
            commands = new ConcurrentQueue<byte[]>();
            workeradded = 0;
            is_waited = 0;
            is_locked = 0;
        }

        internal void Queue_command(byte[] command)
        {
            commands.Enqueue(command);
            Add_worker_thread();
        }

        private void Add_worker_thread()
        {
            if (0 == Interlocked.Exchange(ref workeradded, 1))
            {
                ThreadPool.QueueUserWorkItem(Send_commands);
            }
        }

        private void Send_commands(object state)
        {
            try
            {
                while (commands.TryDequeue(out byte[] command))
                {
                    stream.Write(command);
                }
            }
            catch (Exception se)
            {
                //Console.WriteLine(se.ToString());
                Program.shutdown(id);
            }
            finally
            {
                try
                {
                    Interlocked.Exchange(ref workeradded, 0);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }
    }
}