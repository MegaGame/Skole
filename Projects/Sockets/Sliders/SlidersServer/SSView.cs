using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SlidersServer
{
    public partial class SSView : Form
    {
        List<ClientHandler> listeMedClienter = new List<ClientHandler>();
        
        public SSView()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            Thread t = new Thread(start);
            t.Start();            
        }
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
            textBox1.Text += text + Environment.NewLine;
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
}
