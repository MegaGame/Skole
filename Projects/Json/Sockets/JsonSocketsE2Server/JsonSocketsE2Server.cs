using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace JsonSocketsE2Server
{
    class JsonSocketsE2Server
    {
        static void Main(string[] args)
        {
            Socket listener = new Socket(AddressFamily.InterNetwork,
            SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Any, 11000);
            listener.Bind(localEndPoint);
            listener.Listen(10);
            Program run = new Program();
            while (true)
            {                
                run.start(listener);                           
            }            
            Console.ReadLine();
        }        
    }
    public class Program
    {
        public void start(Socket listener)
        {
            Console.WriteLine("Server: Waiting for a connection...");
            Socket handler = listener.Accept();
            Console.WriteLine("Server: Connection established.");

            while (true)
            {
                try
                {
                    byte[] bytes = new byte[1024];
                    Console.WriteLine("Server: Listen for data from Client.");
                    int bytesRec = handler.Receive(bytes);
                    String data = Encoding.ASCII.GetString(bytes, 0, bytesRec);
                    Head head = Newtonsoft.Json.JsonConvert.DeserializeObject<Head>(data);
                    Console.WriteLine("Server: Data received: Name: " + head.navn + " ID: " + head.id);
                }
                catch (Exception)
                {                    
                    break;
                }                
            }
            handler.Shutdown(SocketShutdown.Both);
            handler.Close();
        }
    }
    public class Head
    {
        public String ClassName = "Head";
        public int id;
        public String navn;
    }
}
