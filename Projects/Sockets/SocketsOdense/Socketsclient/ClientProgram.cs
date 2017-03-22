using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;

namespace Socketsclient
{
    class ClientProgram
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    TcpClient server = new TcpClient("localhost", 8000);
                    NetworkStream stream = server.GetStream();
                    StreamReader reader = new StreamReader(stream);
                    StreamWriter writer = new StreamWriter(stream);
                    writer.AutoFlush = true;
                    Console.WriteLine(reader.ReadLine());
                    while (true)
                    {
                        writer.WriteLine(Console.ReadLine());
                        Console.WriteLine(reader.ReadLine());                        
                    }
                }
                catch (Exception)
                {

                    Console.WriteLine("Server did not respon. Will try reconnect in 5seconds");
                    System.Threading.Thread.Sleep(5000);
                }
            }  
        }
    }
}
