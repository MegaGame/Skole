using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Client
{
    static public class Connect
    {
        static private TcpClient server;
        static public NetworkStream stream;

        static Connect()
        {
            TryConnect();
        }
        static public bool TryConnect()
        {
            while (true)
            {
                try
                {
                    server = new TcpClient("localhost", 8000);
                    stream = server.GetStream();
                    break;
                }
                catch (Exception)
                {

                    Console.WriteLine("Server did not respon. Will try reconnect in 5 seconds");
                    System.Threading.Thread.Sleep(5000);
                }
            }
            return true;            
        }        
    }
}
