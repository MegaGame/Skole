using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace SocketsServer
{
    class ClientHandler
    {
        Socket client;
        public ClientHandler(Socket client)
        {
            this.client = client;
        }
        public void RunClient()
        {
            NetworkStream stream = new NetworkStream(client);
            StreamReader reader = new StreamReader(stream);
            StreamWriter writer = new StreamWriter(stream);
            writer.AutoFlush = true;            
            Console.WriteLine(client.RemoteEndPoint);
            writer.WriteLine("Ready");
            while (true)
            {                
                string input;
                try
                {
                    input = reader.ReadLine();
                }
                catch (Exception)
                {

                    break;
                }
                if (input.Length > 0)
                {
                    if (input.Equals("Hello Server"))
                    {
                        writer.WriteLine("Hello Client");
                    }
                    else if (input.Equals("Time"))
                    {
                        writer.WriteLine(DateTime.Now.ToString("T"));
                    }
                    else if (input.Equals("Date"))
                    {
                        writer.WriteLine(DateTime.Now.ToString("dd\\/MM\\/yyyy"));
                    }
                    else if (input.Equals("Exit"))
                    {
                        break;
                    }
                    else
                    {
                        writer.WriteLine("unknown command");
                    }
                }
                else
                {
                    writer.WriteLine("unknown command");
                }
            }
            reader.Close();
            writer.Close();
            client.Close();
        }
    }
}
