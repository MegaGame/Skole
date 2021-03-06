﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;


namespace Sliders
{
    class Connecter
    {
        public void Connect()
        {
            //-----Establising Connection--------------
            IPEndPoint remoteEP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 11000);
            Socket sender = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            
            sender.Connect(remoteEP);
            

            //------ Create a Listener -----------
            Lytter lytter = new Lytter(sender);

            //------ Sending data -----------
            for (int i = 0; i < 4; i++)
            {
                String besked = Console.ReadLine();
                byte[] msg = Encoding.ASCII.GetBytes(besked);
                
                int bytesSent = sender.Send(msg);
                
            }
            

            sender.Shutdown(SocketShutdown.Both);
            sender.Close();
        }
    }
}
