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
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace XO_The_Game
{
    public partial class XOForm : Form
    {
        Socket handler;
        
        public XOForm()
        {
            InitializeComponent();            
            
        }
        public void AppendMove(Move move)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<Move>(AppendMove), new object[] { move });
                return;
            }
            MakeAMove(move);
            AppendText(move.player);
        }
        public void AppendText(string text)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(AppendText), new object[] { text });
                return;
            }
            textBoxIP.Text = text;
        }

        public void MakeAMove(Move move)
        {

        }
        public void SendAMove(Move move)
        {
            string JsonS = Newtonsoft.Json.JsonConvert.SerializeObject(move);
            byte[] msg = Encoding.ASCII.GetBytes(JsonS);            
            int bytesSent = handler.Send(msg);
        }
        public void lytter()
        {
            while (true)
            {
                try
                {
                    byte[] bytes = new byte[1024];                    
                    int bytesRec = handler.Receive(bytes);
                    String data = Encoding.ASCII.GetString(bytes, 0, bytesRec);
                    Move move = Newtonsoft.Json.JsonConvert.DeserializeObject<Move>(data);
                    AppendMove(move);
                }
                catch (Exception)
                {
                }
            }            
        }

        private void buttonHost_Click(object sender, EventArgs e)
        {
            new Thread(Host).Start();
        }
        public void Host()
        {
            AppendText("Venter på spiller");
            Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Any, 11000);
            listener.Bind(localEndPoint);
            listener.Listen(10);
            handler = listener.Accept();
            AppendText("spiller fundet");

            new Thread(lytter).Start();
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            IPEndPoint remoteEP = new IPEndPoint(IPAddress.Parse(textBoxIP.Text), 11000);
            handler = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            handler.Connect(remoteEP);

            new Thread(lytter).Start();            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Move m = new Move();
            m.player = "X";
            SendAMove(m);
        }
    }
}
