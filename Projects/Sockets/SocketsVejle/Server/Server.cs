using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Server
{
    class Server
    {
        ////E1
        //static void Main(string[] args)
        //{
        //    //-----Establising Connection--------------
        //    Socket listener = new Socket(AddressFamily.InterNetwork,
        //    SocketType.Stream, ProtocolType.Tcp);
        //    IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Any, 11000);
        //    listener.Bind(localEndPoint);
        //    listener.Listen(10);
        //    Console.WriteLine("Server: Waiting for a connection...");
        //    Socket handler = listener.Accept();
        //    Console.WriteLine("Server: Connection established.");
        //}

        ////E2
        //static void Main(string[] args)
        //{
        //    //-----Establising Connection--------------
        //    Socket listener = new Socket(AddressFamily.InterNetwork,
        //    SocketType.Stream, ProtocolType.Tcp);
        //    IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Any, 11000);
        //    listener.Bind(localEndPoint);
        //    listener.Listen(10);
        //    Console.WriteLine("Server: Waiting for a connection...");
        //    Socket handler = listener.Accept();
        //    Console.WriteLine("Server: Connection established.");

        //    //------ Listening for data -----------
        //    byte[] bytes = new byte[1024];
        //    Console.WriteLine("Server: Listen for data from Client.");
        //    int bytesRec = handler.Receive(bytes);
        //    String data = Encoding.ASCII.GetString(bytes, 0, bytesRec);
        //    Console.WriteLine("Server: Data received: " + data);

        //    handler.Shutdown(SocketShutdown.Both);
        //    handler.Close();

        //    Console.ReadLine();
        //}

        ////E3
        //static void Main(string[] args)
        //{
        //    //-----Establising Connection--------------
        //    Socket listener = new Socket(AddressFamily.InterNetwork,
        //    SocketType.Stream, ProtocolType.Tcp);
        //    IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Any, 11000);
        //    listener.Bind(localEndPoint);
        //    listener.Listen(10);
        //    Console.WriteLine("Server: Waiting for a connection...");
        //    Socket handler = listener.Accept();
        //    Console.WriteLine("Server: Connection established.");

        //    //------ Listening for data -----------
        //    byte[] bytes = new byte[1024];
        //    for (int i = 0; i < 5; i++)
        //    {
        //        Console.WriteLine("Server: Listen for data from Client.");
        //        int bytesRec = handler.Receive(bytes);
        //        String data = Encoding.ASCII.GetString(bytes, 0, bytesRec);
        //        Console.WriteLine("Server: Data received: " + data);
        //    }

        //    handler.Shutdown(SocketShutdown.Both);
        //    handler.Close();

        //    Console.ReadLine();

        //}

        ////E4
        //static void Main(string[] args)
        //{
        //    Socket listener = new Socket(AddressFamily.InterNetwork,
        //    SocketType.Stream, ProtocolType.Tcp);
        //    IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Any, 11000);
        //    listener.Bind(localEndPoint);
        //    listener.Listen(10);

        //    //-----Establising Connection--------------
        //    for (int i = 0; i < 3; i++)
        //    {
        //        Console.WriteLine("Server: Waiting for a connection...");
        //        Socket handler = listener.Accept();
        //        Console.WriteLine("Server: Connection established.");

        //        ClientHandler c = new ClientHandler(handler);
        //    }
        //}
        //class ClientHandler
        //{
        //    Socket handler;
        //    public ClientHandler(Socket socket)
        //    {
        //        handler = socket;
        //        Thread traad = new Thread(Listen);
        //        traad.Start();
        //    }
        //    private void Listen()
        //    {
        //        //------ Listening for data -----------
        //        for (int i = 0; i < 5; i++)
        //        {
        //            byte[] bytes = new byte[1024];
        //            Console.WriteLine("Server: Listen for data from Client.");
        //            int bytesRec = handler.Receive(bytes);
        //            String data = Encoding.ASCII.GetString(bytes, 0, bytesRec);
        //            Console.WriteLine("Server: Data received: " + data);
        //        }
        //        Console.WriteLine("Server: Handler/Thread closing");
        //        handler.Shutdown(SocketShutdown.Both);
        //        handler.Close();
        //        Thread.CurrentThread.Abort();
        //    }
        //}

        //    //E5
        //    static void Main(string[] args)
        //    {
        //        Serveren serveren = new Serveren();
        //        serveren.start();
        //    }
        //}
        //class Serveren
        //{
        //    List<ClientHandler> listeMedClienter = new List<ClientHandler>();
        //    public void start()
        //    {
        //        Socket listener = new Socket(AddressFamily.InterNetwork,
        //        SocketType.Stream, ProtocolType.Tcp);
        //        IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Any, 11000);
        //        listener.Bind(localEndPoint);
        //        listener.Listen(10);

        //        //-----Establising Connection--------------
        //        for (int i = 0; i < 3; i++)
        //        {
        //            udskrivTilSkærm("Server: Waiting for a connection...");
        //            Socket handler = listener.Accept();
        //            udskrivTilSkærm("Server: Connection established.");

        //            ClientHandler c = new ClientHandler(handler, this);
        //            listeMedClienter.Add(c);
        //        }
        //    }
        //    public void udskrivTilSkærm(String text)
        //    {
        //        Console.WriteLine(text);
        //    }
        //}
        //class ClientHandler
        //{
        //    Socket handler;
        //    Serveren serveren;
        //    public ClientHandler(Socket socket, Serveren serv)
        //    {
        //        handler = socket;
        //        serveren = serv;
        //        Thread traad = new Thread(Listen);
        //        traad.Start();
        //    }
        //    private void Listen()
        //    {
        //        //------ Listening for data -----------
        //        for (int i = 0; i < 5; i++)
        //        {
        //            byte[] bytes = new byte[1024];
        //            serveren.udskrivTilSkærm("Server: Listen for data from Client.");
        //            int bytesRec = handler.Receive(bytes);
        //            String data = Encoding.ASCII.GetString(bytes, 0, bytesRec);
        //            serveren.udskrivTilSkærm("Server: Data received: " + data);
        //        }
        //        serveren.udskrivTilSkærm("Server: Handler/Thread closing");
        //        handler.Shutdown(SocketShutdown.Both);
        //        handler.Close();
        //        Thread.CurrentThread.Abort();
        //    }

        //E6
        static void Main(string[] args)
        {
            Serveren serveren = new Serveren();
            serveren.start();
        }
    }
    class Serveren
    {
        List<ClientHandler> listeMedClienter = new List<ClientHandler>();
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
            Console.WriteLine(text);
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
    class ClientHandler
    {
        Socket handler;
        Serveren serveren;
        public ClientHandler(Socket socket, Serveren serv)
        {
            handler = socket;
            serveren = serv;
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
                serveren.udskrivTilSkærm("Server: Listen for data from Client.");
                int bytesRec = handler.Receive(bytes);
                String data = Encoding.ASCII.GetString(bytes, 0, bytesRec);
                serveren.udskrivTilSkærm("Server: Data received: " + data);
                serveren.multicastToAllClient(data);
            }
            serveren.udskrivTilSkærm("Server: Handler/Thread closing");
            handler.Shutdown(SocketShutdown.Both);
            handler.Close();
            Thread.CurrentThread.Abort();
        }
        
    }
}
