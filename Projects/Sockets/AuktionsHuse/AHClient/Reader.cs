using System;
using System.IO;
using System.Net.Sockets;

namespace Client
{
    class Reader
    {
        
        StreamReader reader;
        public Reader(NetworkStream stream)
        {            
            reader = new StreamReader(stream);
        }
        public void Excute()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine(reader.ReadLine());
                }
                catch (Exception)
                {
                    
                }
                
            }
        }
    }
}
