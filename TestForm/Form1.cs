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
        }
        public void AppendText(string text)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(AppendText), new object[] { text });
                return;
            }
            textBox1.Text = text + Environment.NewLine;
        }
        public void run()
        {
            AddText at = new AddText(AppendText);

            TestForm2.Tester t = new TestForm2.Tester(at);
            Thread x = new Thread(t.run);
            x.Start();



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
}
