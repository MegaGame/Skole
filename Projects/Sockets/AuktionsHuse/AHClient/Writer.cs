using System;
using System.IO;
using System.Net.Sockets;

namespace Client
{
    class Writer
    {
        StreamWriter writer;

        public Writer(NetworkStream stream)
        {
            writer = new StreamWriter(stream);
            writer.AutoFlush = true;
        }
        public void Excute()
        {
            while (true)
            {
                try
                {
                    writer.WriteLine(Console.ReadLine());
                }
                catch (Exception)
                {
                    
                }
            }
        }
    }
}
