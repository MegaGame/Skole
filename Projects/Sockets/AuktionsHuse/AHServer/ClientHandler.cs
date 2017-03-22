using System;
using System.IO;
using System.Net.Sockets;
using System.Threading;

namespace Server
{
    internal class ClientHandler
    {
        private Socket client;

        public ClientHandler(Socket client)
        {
            this.client = client;
        }

        internal void RunClient()
        {
            NetworkStream stream = new NetworkStream(client);
            StreamReader reader = new StreamReader(stream);
            StreamWriter writer = new StreamWriter(stream);
            writer.AutoFlush = true;
            Console.WriteLine(client.RemoteEndPoint);
            writer.WriteLine("Current bid:" + CurrentBid.GetCurrentBid());

            Reporter br = new Reporter(writer);
            Thread reporterB = new Thread(br.ReportBid);
            reporterB.Start();
            Thread reporterS = new Thread(br.ReportStatus);
            reporterS.Start();          

            while (true)
            {                
                try
                {
                    int bid = 0;
                    string input = reader.ReadLine();
                    try
                    {
                        bid = Convert.ToInt32(input);
                    }
                    catch (Exception)
                    {
                        writer.WriteLine("Please enter a number.");
                    }
                    if (bid > 0)
                    {
                        bool bidSucces = CurrentBid.SetCurrentBid(bid, client.RemoteEndPoint.ToString());
                        if (bidSucces == true)
                        {
                            writer.WriteLine("You are now highst bidder");
                            Console.WriteLine(client.RemoteEndPoint + " New highst bid: " + bid.ToString());
                            AuctionStopper.Reset();
                        }
                        else
                        {
                            writer.WriteLine("Bid was to low.");
                        }
                    }
                }
                catch (Exception)
                {

                    break;
                }
            }
            reader.Close();
            writer.Close();
            client.Close();
        }
    }
}