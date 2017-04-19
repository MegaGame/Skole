using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

//ændre namespace til det projeket der er i
namespace XO_The_Game
{
    public class SocketController
    {        
        Form form; //ænder til at passe med UI

        public SocketController(Form f)//ænder til at passe med UI
        {
            form = f;
        }
        public void HostStart()
        {
            Socket host = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Any, 11000);
            host.Bind(localEndPoint);
            host.Listen(10);
            HostOneToOne(host.Accept());
            //HostOneToMany(host);
            
        }
        public void HostOneToOne(Socket soc)
        {
            DataController dc = new DataController(soc);
            new Thread(dc.Listener).Start();
        }
        public void HostOneToMany(Socket soc)
        {
            
            while (true)
            {
                Socket s = soc.Accept();
                DataController dc = new DataController(s);
                new Thread(dc.Listener).Start();
            }
        }
        

    }
    public class DataController
    {
        Socket handler;
        public DataController(Socket soc)
        {
            handler = soc;
        }
        public void Listener()
        {
            while (true)
            {
                try
                {
                    byte[] bytes = new byte[1024];
                    int bytesRec = handler.Receive(bytes);
                    String data = Encoding.ASCII.GetString(bytes, 0, bytesRec);
                    DataIn(data);
                }
                catch (Exception)
                {
                }
            }
        }
        private void DataIn(string data) //ændre for hvad data der modtages og hvor det skal vises
        {
            JsonDataIn(data);
        }
        private void JsonDataIn(string data)//ændre return type til passe hvad DeserializeObject er
        {
            Move move = Newtonsoft.Json.JsonConvert.DeserializeObject<Move>(data); //ændre object der modtages
        }
        private void DataOut()
        {

        }
    }
    
}
