using System;
using System.Net.Sockets;
using System.Threading;

namespace Client
{
    class Client
    {
        
        static void Main(string[] args)
        {
            if (Connect.TryConnect())
            {
                Reader reader = new Reader(Connect.stream);
                Thread readThread = new Thread(reader.Excute);
                readThread.Start();

                Writer writer = new Writer(Connect.stream);
                Thread writeThread = new Thread(writer.Excute);
                writeThread.Start();
            }            
        }
    }
}
