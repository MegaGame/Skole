using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace _3.sem01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Thread t;
        List<Cirkel> listCirkler = new List<sem01.Cirkel>();

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 20; i++)
            {
                listCirkler.Add(new Cirkel());
            }
            t = new Thread(runAll);
            t.Start();
        }

        public void runAll()
        {

            for (int i = 0; i < 1000; i++)
            {
                tegnAlt();
                Thread.Sleep(100);
            }

        }
        
        public void tegnAlt()
        {
            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(Color.FloralWhite);
            Pen pen1 = new Pen(Color.Red, 4F);
            int k = 20;
            foreach (Cirkel c in listCirkler)
            {
                k = k + 20;
                g.DrawEllipse(pen1, c.xPos, c.yPos+k, 10, 10);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            t.Abort();
            foreach (Cirkel c in listCirkler)
            {
                c.t.Abort();
            }
        }
    }
    class Cirkel
    {
        public static Random rand = new Random();
        public int xPos = 20;
        public int yPos = 20;
        public Thread t;
        public static int getRandom()
        {
            return rand.Next(1, 5);
        }
        public Cirkel ()
        {
            t = new Thread(flyt);
            t.Start(); 
        }

        public void flyt()
        {
            while (true)
            {
                int g = getRandom();
                if(g==1)
                    xPos = xPos + 5;
                if (g == 2)
                    xPos = xPos - 5;
                if (g == 3)
                    yPos = yPos + 5;
                if (g == 4)
                    yPos = yPos - 5;


                if (xPos < 0)
                    xPos = 100;
                if (xPos > 200)
                    xPos = 50;
                if (yPos < 0)
                    yPos = 100;
                if (yPos > 200)
                    yPos = 50;
                Thread.Sleep(100);
            }
        }
    }
}
