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

namespace TestForm
{
    public delegate void AddText(string text);

    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            run();
            run2();
        }
        public void AppendText(string text)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(AppendText), new object[] { text });
                return;
            }
            textBox1.Text += text + Environment.NewLine;
        }
        public void AppendText2(string text)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(AppendText2), new object[] { text });
                return;
            }
            textBox2.Text += text + Environment.NewLine;
        }
        public void run()
        {
            AddText at = new AddText(AppendText);

            TestForm2.Tester t = new TestForm2.Tester(at);
            Thread x = new Thread(t.run);
            x.Start();
        }
        public void run2()
        {
            TestForm2.Tester2 t2 = new TestForm2.Tester2();
            Thread y = new Thread(t2.run);
            y.Start();
            try
            {
                t2.counting += AppendText2;
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
namespace TestForm2
{ 
    public class Tester
    {
        int i = 0;
        TestForm.AddText D;
        public Tester(TestForm.AddText d)
        {
            D = d;
        }
        private string Counter()
        {
            return i++.ToString();
        }
        public void run()
        {
            while (i < 50)
            {               
                D(Counter());
                Thread.Sleep(200);
            }
        }
    }
    public class Tester2
    {
        public event Action<string> counting;
        int i = 0;

        private string Counter()
        {
            return i++.ToString();
        }
        public void run()
        {
            while (i < 50)
            {
                counting(Counter());
                Thread.Sleep(200);
            }
        }
    }
}
