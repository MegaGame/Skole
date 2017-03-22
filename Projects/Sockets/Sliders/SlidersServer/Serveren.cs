using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SlidersServer
{
    class Serveren
    {
        List<ClientHandler> listeMedClienter = new List<ClientHandler>();
        SSView screen;
        public Serveren(SSView screen)
        {
            this.screen = screen;
        }
        public void start()
        {
            Socket listener = new Socket(AddressFamily.InterNetwork,
            SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Any, 11000);
            listener.Bind(localEndPoint);
            listener.Listen(10);

            //-----Establising Connection--------------
            for (int i = 0; i < 3; i++)
            {
                udskrivTilSkærm("Server: Waiting for a connection...");
                Socket handler = listener.Accept();
                udskrivTilSkærm("Server: Connection established.");

                ClientHandler c = new ClientHandler(handler, this);
                listeMedClienter.Add(c);
            }
        }
        public void udskrivTilSkærm(String text)
        {
            screen.Print(text);
        }
        public void multicastToAllClient(String text)
        {
            //---Multicasting to ALLE clients---------------
            foreach (ClientHandler ch in listeMedClienter)
            {
                ch.sendData(text);
            }
        }
    }
}
