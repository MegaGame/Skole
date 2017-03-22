using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketsServer
{
    class ServerProgram
    {
        static void Main(string[] args)
        {
            EchoSocketServer es = new EchoSocketServer(8000);        
        }
    }
}
