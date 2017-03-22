using System;
using System.Windows.Forms;

namespace JsonVersion1
{
    public partial class FormJV1 : Form
    {
        public FormJV1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.MissingMemberHandling = MissingMemberHandling.Error;

            Head head = new Head();
            head.id = 211;
            Hale hale = new Hale();
            hale.navn = "Paul";

            string Json = Newtonsoft.Json.JsonConvert.SerializeObject(hale);

            try
            {
                Head obj = Newtonsoft.Json.JsonConvert.DeserializeObject<Head>(Json, settings);
                HeadObjektFundet(obj);
            }
            catch (Exception eHead)
            {                
                listBox1.Items.Add("FEJL: Objekt er ikke Head");
            }

            try
            {
                Hale obj = Newtonsoft.Json.JsonConvert.DeserializeObject<Hale>(Json, settings);
                HaleObjektFundet(obj);
            }
            catch (Exception eHale)
            {
                listBox1.Items.Add("FEJL: Objekt er ikke Hale");
            }

        }
        public void HeadObjektFundet(Head h)
        {
            listBox1.Items.Add("HEAD ID = " + h.id);
        }
        public void HaleObjektFundet(Hale h)
        {
            listBox1.Items.Add("HALE Navn = " + h.navn);
        }
    }
    public class Head
    {
        public int id;
    }
    public class Hale
    {
        public String navn;
    }
}