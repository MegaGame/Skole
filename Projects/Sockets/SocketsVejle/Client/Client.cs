using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Client
{
    class Client
    {
        ////E1
        //static void Main(string[] args)
        //{
        //    //-----Establising Connection--------------
        //    IPEndPoint remoteEP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 11000);
        //    Socket sender = new Socket(AddressFamily.InterNetwork,
        //                  SocketType.Stream, ProtocolType.Tcp);
        //    Console.WriteLine("Client: Trying to Connect to server.");
        //    sender.Connect(remoteEP);
        //    Console.WriteLine("Client: Connection established.");
        //    Console.ReadLine();

        //}

        ////E2
        //static void Main(string[] args)
        //{
        //    //-----Establising Connection--------------
        //    IPEndPoint remoteEP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 11000);
        //    Socket sender = new Socket(AddressFamily.InterNetwork,
        //                  SocketType.Stream, ProtocolType.Tcp);
        //    Console.WriteLine("Client: Trying to Connect to server.");
        //    sender.Connect(remoteEP);
        //    Console.WriteLine("Client: Connection established.");

        //    //------ Sending data -----------
        //    byte[] msg = Encoding.ASCII.GetBytes(
        //                    "My first message to Server.");
        //    Console.WriteLine("Client: Sending data to Server.");
        //    int bytesSent = sender.Send(msg);
        //    Console.WriteLine("Client: Date sent.");

        //    sender.Shutdown(SocketShutdown.Both);
        //    sender.Close();

        //    Console.ReadLine();
        //}

        ////E3
        //static void Main(string[] args)
        //{
        //    //-----Establising Connection--------------
        //    IPEndPoint remoteEP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 11000);
        //    Socket sender = new Socket(AddressFamily.InterNetwork,
        //                  SocketType.Stream, ProtocolType.Tcp);
        //    Console.WriteLine("Client: Trying to Connect to server.");
        //    sender.Connect(remoteEP);
        //    Console.WriteLine("Client: Connection established.");

        //    //------ Sending data -----------
        //    for (int i = 0; i < 5; i++)
        //    {
        //        String besked = Console.ReadLine();
        //        byte[] msg = Encoding.ASCII.GetBytes(besked);
        //        Console.WriteLine("Client: Sending data to Server.");
        //        int bytesSent = sender.Send(msg);
        //        Console.WriteLine("Client: Date sent.");
        //    }
        //    sender.Shutdown(SocketShutdown.Both);
        //    sender.Close();

        //    Console.ReadLine();
        //}

        ////E4
        //static void Main(string[] args)
        //{
        //    //-----Establising Connection--------------
        //    IPEndPoint remoteEP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 11000);
        //    Socket sender = new Socket(AddressFamily.InterNetwork,
        //                  SocketType.Stream, ProtocolType.Tcp);
        //    Console.WriteLine("Client: Trying to Connect to server.");
        //    sender.Connect(remoteEP);
        //    Console.WriteLine("Client: Connection established.");

        //    //------ Sending data -----------
        //    for (int i = 0; i < 4; i++)
        //    {
        //        String besked = Console.ReadLine();
        //        byte[] msg = Encoding.ASCII.GetBytes(besked);
        //        Console.WriteLine("Client: Sending data to Server.");
        //        int bytesSent = sender.Send(msg);
        //        Console.WriteLine("Client: Date sent.");
        //    }
        //    Console.WriteLine("Client: Sender closing");

        //    sender.Shutdown(SocketShutdown.Both);
        //    sender.Close();
        //}

        ////E5
        //static void Main(string[] args)
        //{
        //    //-----Establising Connection--------------
        //    IPEndPoint remoteEP = new IPEndPoint(IPAddress.Parse
        //                       ("127.0.0.1"), 11000);
        //    Socket sender = new Socket(AddressFamily.InterNetwork,
        //                  SocketType.Stream, ProtocolType.Tcp);
        //    Console.WriteLine("Client: Trying to Connect to server.");
        //    sender.Connect(remoteEP);
        //    Console.WriteLine("Client: Connection established.");

        //    //------ Sending data -----------
        //    for (int i = 0; i < 4; i++)
        //    {
        //        String besked = Console.ReadLine();
        //        byte[] msg = Encoding.ASCII.GetBytes(besked);
        //        Console.WriteLine("Client: Sending data to Server.");
        //        int bytesSent = sender.Send(msg);
        //        Console.WriteLine("Client: Date sent.");
        //    }
        //    Console.WriteLine("Client: Sender closing");

        //    sender.Shutdown(SocketShutdown.Both);
        //    sender.Close();
        //}

        //E6
        static void Main(string[] args)
        {
            //-----Establising Connection--------------
            IPEndPoint remoteEP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 11000);
            Socket sender = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Console.WriteLine("Client: Trying to Connect to server.");
            sender.Connect(remoteEP);
            Console.WriteLine("Client: Connection established.");

            //------ Create a Listener -----------
            Lytter lytter = new Lytter(sender);

            //------ Sending data -----------
            for (int i = 0; i < 4; i++)
            {
                String besked = Console.ReadLine();
                byte[] msg = Encoding.ASCII.GetBytes(besked);
                Console.WriteLine("Client: Sending data to Server.");
                int bytesSent = sender.Send(msg);
                Console.WriteLine("Client: Date sent.");
            }
            Console.WriteLine("Client: Sender closing");

            sender.Shutdown(SocketShutdown.Both);
            sender.Close();
        }
    }
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
                Console.WriteLine("Client: Listen for data from Server.");
                int bytesRec = sender.Receive(bytes);
                String data = Encoding.ASCII.GetString(bytes, 0, bytesRec);
                Console.WriteLine("Client: Data received: " + data);
            }
            Console.WriteLine("Client: sender/Thread closing");
            sender.Shutdown(SocketShutdown.Both);
            sender.Close();
            Thread.CurrentThread.Abort();
        }

    }
}
