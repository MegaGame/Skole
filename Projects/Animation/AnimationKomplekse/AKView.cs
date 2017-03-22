using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnimationKomplekse
{
    public partial class AKView : Form
    {
        Thread trad;
        Bitmap bmp;
        private Graphics minGraphics;
        int posX = 0;
        int posY = 0;
        Bitmap billede;

        public AKView()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (trad == null)
            {
                trad = new Thread(trådMetoden);
                trad.Start();
            }
            try
            {
                billede = new Bitmap(Application.StartupPath + @"\briller.png");
                // billede.MakeTransparent();
            }
            catch (Exception dk)
            { }
        }

        public void trådMetoden()
        {
            while (true)
            {
                Thread.Sleep(5);
                paintNu();
            }
        }
        public void paintNu()
        {
            posX++;
            posY++;

            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            minGraphics = Graphics.FromImage(bmp);
            minGraphics.Clear(Color.White);
            //---------TEGNING-START----------------------------------------------------

            //--------TEKST AFDELING----------
            Font drawFont = new Font("Arial", 12);
            SolidBrush drawBrush = new SolidBrush(Color.Red);
            minGraphics.DrawString("C# animation." + posX + ":" + posY, drawFont, drawBrush, posX + 5, posY + 5);

            //--------REKTANGEL AFDELING------
            Pen pen1 = new Pen(Color.Blue, 4F);
            minGraphics.DrawRectangle(pen1, posX, posY, 250, 40);

            //--------ELIPSE AFDELINGEN-------
            pen1 = new Pen(Color.Green, 4F);
            minGraphics.DrawEllipse(pen1, 100 + posX, 30, 60, 30);

            //---------STREGE/PIL AFDELINGEN------
            Pen p = new Pen(Color.Black, 5);
            p.CustomEndCap = new System.Drawing.Drawing2D.AdjustableArrowCap(5, 5, false);
            minGraphics.DrawLine(p, posX, posY, 130 + posX, 60);

            //---------BILLEDER AFDELINGEN----------
            if (billede != null)
                minGraphics.DrawImage(billede, new Point(posX, posY + 50));

            //---------TEGNING-SLUT----------------------------------------------------
            pictureBox1.Image = bmp;
            pictureBox1.Update();
            if (posX > pictureBox1.Width - 200)
            {
                posX = 0;
            }
            if (posY > pictureBox1.Height - 50)
            {
                posY = 0;
            }
        }

    }
}
