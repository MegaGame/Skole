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
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            startDetHele();
        }

        private static Random rnd = new Random();
        public static int GetRandom(int start, int slut)
        {
            return rnd.Next(start, slut);
        }
        List<Thread> traadListe = new List<Thread>();
        Board board;
        public void startDetHele()
        {
            board = new Board();
            lavNogleDyr();
            Thread t = new Thread(paint);
            t.Start();
            traadListe.Add(t);
        }
        List<Dyr> minDyrListe = new List<Dyr>();
        public bool tjekOmKaninerEksisterer()
        {
            bool svar = false;
            foreach (Dyr d in minDyrListe)
            {
                if( d is Kanin)
                {
                    svar = true;
                    break;                    
                }
            }
                return svar;
        }
        public void collisionControle()
        {
            List<Dyr> sleteListe = new List<Dyr>();
            foreach (Dyr d in minDyrListe)
            {
                foreach (Dyr a in minDyrListe)
                {
                    if (d != a)
                    {
                        if (d.minPoint == a.minPoint)
                        {
                            if (d is Løve && a is Kanin)
                            {
                                sleteListe.Add(a);
                            }
                            //sleteListe.Add(a);
                        }
                    }
                }
            }
            foreach (Dyr d in sleteListe)
            {
                minDyrListe.Remove(d);
            }

        }
        public void lavNogleDyr()
        {
           
            minDyrListe = new List<Dyr>();
            for (int i = 0; i < GetRandom(3,20); i++)
            {
                Løve l = new Løve(board);
                l.minPoint = board.givMigTilfældigPoint();
                minDyrListe.Add(l);
                Thread t = new Thread(l.move);
                t.Start();
                traadListe.Add(t);
            }
            for (int i = 0; i < GetRandom(3, 20); i++)
            {
                Kanin l = new Kanin(board);
                l.minPoint = board.givMigTilfældigPoint();
                minDyrListe.Add(l);
                Thread t = new Thread(l.move);
                t.Start();
                traadListe.Add(t);
            }
        }
        Bitmap bmp;
        private Graphics minGraphics;
        public void paint()
        {
            int runder = 0;
            while (true)
            {
                runder++;
                Thread.Sleep(30);
                if (runder > 100)
                {
                    collisionControle();
                    if( tjekOmKaninerEksisterer()==false)
                    {
                        stopEverything();
                    }
                }
                bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                minGraphics = Graphics.FromImage(bmp);
                minGraphics.Clear(Color.White);
                //---------TEGNING-START-----------------
                board.paintMySelf(minGraphics);
                foreach (Dyr d in minDyrListe)
                {
                    d.paintMySelf(minGraphics);
                }




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

            public Point givMigTilfældigPoint()
            {
                return boardArray[10, 10];
            }
            public Point moveRight(Point minPoint)
            {
                int aktuelX = 0;
                int aktuelY = 0;
                for (int i = 0; i < 20; i++)
                {
                    for (int j = 0; j < 20; j++)
                    {
                        if (minPoint == boardArray[i, j])
                        {
                            aktuelX = i;
                            aktuelY = j;
                        }
                    }
                }
                if (aktuelX < 19)
                    aktuelX++;

                return boardArray[aktuelX, aktuelY];
            }
            public Point moveLeft(Point minPoint)
            {
                int aktuelX = 0;
                int aktuelY = 0;
                for (int i = 0; i < 20; i++)
                {
                    for (int j = 0; j < 20; j++)
                    {
                        if (minPoint == boardArray[i, j])
                        {
                            aktuelX = i;
                            aktuelY = j;
                        }
                    }
                }
                if (aktuelX > 0)
                    aktuelX--;

                return boardArray[aktuelX, aktuelY];
            }
            public Point moveUp(Point minPoint)
            {
                int aktuelX = 0;
                int aktuelY = 0;
                for (int i = 0; i < 20; i++)
                {
                    for (int j = 0; j < 20; j++)
                    {
                        if (minPoint == boardArray[i, j])
                        {
                            aktuelX = i;
                            aktuelY = j;
                        }
                    }
                }
                if (aktuelY > 0)
                    aktuelY--;

                return boardArray[aktuelX, aktuelY];
            }
            public Point moveDown(Point minPoint)
            {
                int aktuelX = 0;
                int aktuelY = 0;
                for (int i = 0; i < 20; i++)
                {
                    for (int j = 0; j < 20; j++)
                    {
                        if (minPoint == boardArray[i, j])
                        {
                            aktuelX = i;
                            aktuelY = j;
                        }
                    }
                }
                if (aktuelY < 19)
                    aktuelY++;

                return boardArray[aktuelX, aktuelY];
            }

        }

        class Dyr
        {
            public Point minPoint;
            public Board mitBoard;
            public Dyr(Board b)
            {
                mitBoard = b;
            }
            public virtual void paintMySelf(Graphics g)
            {
            }
            public virtual void move()
            {

            }
        }
        class Løve : Dyr
        {
            public Løve(Board b): base(b)
            {
            }
            public override void paintMySelf(Graphics g)
            {
                Pen pen1 = new Pen(Color.Red, 4F);
                g.DrawRectangle(pen1, minPoint.X, minPoint.Y, 15, 15);
            }
            public override void move()
            {
                int teller = 0;
                int pos = 1;
                while (true)
                {
                    Thread.Sleep(GetRandom(200, 400));
                    if (teller == 0)
                    {
                        pos = GetRandom(1, 5);
                    }
                    teller++;
                    if (pos == 1)
                        minPoint = mitBoard.moveRight(minPoint);
                    if (pos == 2)
                        minPoint = mitBoard.moveLeft(minPoint);
                    if (pos == 3)
                        minPoint = mitBoard.moveUp(minPoint);
                    if (pos == 4)
                        minPoint = mitBoard.moveDown(minPoint);
                    if (teller > 5)
                        teller = 0;

                }
            }
        }
        class Kanin : Dyr
        {
            public Kanin(Board b): base(b)
            {
            }
            public override void paintMySelf(Graphics g)
            {
                Pen pen1 = new Pen(Color.Blue, 4F);
                g.DrawRectangle(pen1, minPoint.X, minPoint.Y, 15, 15);
            }
            public override void move()
            {
                int teller = 0;
                int pos = 1;
                while (true)
                {
                    Thread.Sleep(GetRandom(100, 200));
                    if (teller == 0)
                    {
                        pos = GetRandom(1, 5);
                    }
                    teller++;
                    if (pos == 1)
                        minPoint = mitBoard.moveRight(minPoint);
                    if (pos == 2)
                        minPoint = mitBoard.moveLeft(minPoint);
                    if (pos == 3)
                        minPoint = mitBoard.moveUp(minPoint);
                    if (pos == 4)
                        minPoint = mitBoard.moveDown(minPoint);
                    if (teller > 5)
                        teller = 0;

                }
            }
        }
        private void stopEverything()
        {
            foreach (Thread t in traadListe)
            {
                t.Abort();
            }
            minDyrListe.Clear();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            stopEverything();
            startDetHele();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            foreach (Thread t in traadListe)
            {
                t.Suspend();
            }
            Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Any, 11000);
            listener.Bind(localEndPoint);
            listener.Listen(10);
            Socket handler = listener.Accept();
            foreach  (Thread t in traadListe)
            {
                t.Resume();
            }


        }

        private void Form1_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            foreach (Thread t in traadListe)
            {
                t.Abort();
            }

        }
    }
}
