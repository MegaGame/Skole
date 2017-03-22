using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sliders
{
    class Lytter
    {
        Socket sender;
        Thread t;
        public Lytter(Socket send)
        {
            sender = send;
            t = new Thread(Listen);
            t.Start();
        }
        private void Listen()
        {
            //------ Listening for data -----------
            for (int i = 0; i < 5; i++)
            {
                byte[] bytes = new byte[1024];
                
                int bytesRec = sender.Receive(bytes);
                String data = Encoding.ASCII.GetString(bytes, 0, bytesRec);
                
            }
            
            sender.Shutdown(SocketShutdown.Both);
            sender.Close();
            Thread.CurrentThread.Abort();
        }
    }
}
