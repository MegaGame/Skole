using System;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace JsonSocketsE2Client
{
    class JsonSocketsE2Client
    {
        static void Main(string[] args)
        {
            Head head = new Head();
            head.id = 211;
            head.navn = "Allan";            

            Head head2 = new Head();
            head2.id = 112;
            head2.navn = "Bo";

            //-----Establising Connection--------------
            IPEndPoint remoteEP = new IPEndPoint(IPAddress.Parse
                               ("127.0.0.1"), 11000);
            Socket sender = new Socket(AddressFamily.InterNetwork,
                          SocketType.Stream, ProtocolType.Tcp);
            Console.WriteLine("Client: Trying to Connect to server.");
            sender.Connect(remoteEP);
            Console.WriteLine("Client: Connection established.");
            
            ConcurrentQueue<Head> ls = new ConcurrentQueue<Head>();
            ls.Enqueue(head); //add til enden af listen
            ls.Enqueue(head2);
            while (!ls.IsEmpty) //bruger ConcurrentQueue liste
            {
                Head h;
                if (ls.TryDequeue(out h))//ser om det lykkes at fjerne første object i listen, out for at bruge object.
                {
                    string JsonS = Newtonsoft.Json.JsonConvert.SerializeObject(h);
                    byte[] msg = Encoding.ASCII.GetBytes(JsonS);
                    Console.WriteLine("Client: Sending data to Server.");
                    int bytesSent = sender.Send(msg);
                    Console.WriteLine("Client: Date sent.");
                }
            }
            
            sender.Shutdown(SocketShutdown.Both);
            sender.Close();

            Console.ReadLine();

        }
    }
    public class Head
    {
        public String ClassName = "Head";
        public int id;
        public String navn;
    }
}
