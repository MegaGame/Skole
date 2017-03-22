using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Net;

namespace SocketsServer
{
    class EchoSocketServer
    {
        public EchoSocketServer(int port)
        {
            IPAddress ip = IPAddress.Any;
            TcpListener tl = new TcpListener(ip, port);
            tl.Start();
            while (true)
            {
                Socket client = tl.AcceptSocket();
                ClientHandler ch = new ClientHandler(client);
                Thread thread = new Thread(ch.RunClient);
                thread.Start();
            }
        }
         
    }
}
