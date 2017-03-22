using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SlidersServer
{
    class ClientHandler
    {
        Socket handler;
        SSView viewer;
        public ClientHandler(Socket socket, SSView serv)
        {
            handler = socket;
            viewer = serv;
            Thread traad = new Thread(Listen);
            traad.Start();
        }
        public void sendData(String text)
        {
            byte[] msg = Encoding.ASCII.GetBytes(text);
            int bytesSent = handler.Send(msg);
        }
        private void Listen()
        {
            //------ Listening for data -----------
            for (int i = 0; i < 5; i++)
            {
                byte[] bytes = new byte[1024];
                viewer.udskrivTilSkærm("Server: Listen for data from Client.");
                int bytesRec = handler.Receive(bytes);
                String data = Encoding.ASCII.GetString(bytes, 0, bytesRec);
                viewer.udskrivTilSkærm("Server: Data received: " + data);
                viewer.multicastToAllClient(data);
            }
            viewer.udskrivTilSkærm("Server: Handler/Thread closing");
            handler.Shutdown(SocketShutdown.Both);
            handler.Close();
            Thread.CurrentThread.Abort();
        }

    }
}

