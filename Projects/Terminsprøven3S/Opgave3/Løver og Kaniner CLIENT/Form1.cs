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

namespace Dyr
{
    public partial class Form1 : Form
    {
        Socket handler;        
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            startDetHele();
        }
     
        List<Thread> traadListe = new List<Thread>();
        Board board;
        public void startDetHele()
        {
            board = new Board();
           
            Thread t = new Thread(paint);
            t.Start();
            traadListe.Add(t);
        }
        Bitmap bmp;
        private Graphics minGraphics;
        public void paint()
        {
            int runder = 0;
            while (true)
            {
               
                bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                minGraphics = Graphics.FromImage(bmp);
                minGraphics.Clear(Color.White);
                //---------TEGNING-START-----------------
                board.paintMySelf(minGraphics);
               




                //---------TEGNING-SLUT---------------------------------------------------- 
                pictureBox1.Image = bmp;
                pictureBox1.Update();
            }
        }
        class Board
        {
            Point[,] boardArray = new Point[20, 20];
            public Board()
            {
                for (int i = 0; i < 20; i++)
                {
                    for (int j = 0; j < 20; j++)
                    {
                        boardArray[i, j] = new Point(i * 15, j * 15);
                    }
                }
            }
            public void paintMySelf(Graphics g)
            {
                Pen pen1 = new Pen(Color.Yellow, 2F);
                for (int i = 0; i < 20; i++)
                {
                    for (int j = 0; j < 20; j++)
                    {
                        g.DrawRectangle(pen1, boardArray[i, j].X, boardArray[i, j].Y, 15, 15);
                    }
                }
            }

        }

        private void stopEverything()
        {
            foreach (Thread t in traadListe)
            {
                t.Abort();
            }
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
           
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            IPEndPoint remoteEP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 11000);
            handler = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            handler.Connect(remoteEP);
            new Thread(lytter).Start();
        }

        private void Form1_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            foreach (Thread t in traadListe)
            {
                t.Abort();
            }
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
                    DataDyr dd = Newtonsoft.Json.JsonConvert.DeserializeObject<DataDyr>(data);
                    AppendPoint(dd);
                }
                catch (Exception)
                {
                }
            }
        }        
        private void AppendPoint(DataDyr dd)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<DataDyr>(AppendPoint), new object[] { dd });
                return;
            }
            textBox1.Text = "X: " + dd.DyrPoint.X.ToString() + " Y:" + dd.DyrPoint.Y.ToString();
        }
        class DataDyr
        {
            public String ClassName = "dyr";
            public String Type;
            public Point DyrPoint;

        }

        
    }

}
