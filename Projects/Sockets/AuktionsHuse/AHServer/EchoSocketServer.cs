using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Server
{
    internal class EchoSocketServer
    {
        

        public EchoSocketServer(int port)
        {
            IPAddress ip = IPAddress.Any;
            TcpListener tl = new TcpListener(ip, port);            
            tl.Start();
            CurrentBid.ResetBid();
            AuctionStopper.Start();

            while (true)
            {
                Socket client = tl.AcceptSocket();
                ClientHandler ch = new ClientHandler(client);
                Thread clientThread = new Thread(ch.RunClient);
                clientThread.Start();
            }
        }
    }
}