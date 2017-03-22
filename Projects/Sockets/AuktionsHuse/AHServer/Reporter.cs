using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Reporter
    {
        StreamWriter writer;
        int lastReportedBid;
        public Reporter(StreamWriter writer)
        {
            this.writer = writer;
            writer.AutoFlush = true;            
        }
        public void ReportBid()
        {
            lastReportedBid = CurrentBid.currentBid;
            while (true)
            {
                int currentBid = CurrentBid.currentBid;
                if (currentBid < lastReportedBid)
                {
                    lastReportedBid = 0;
                }              
                if (currentBid > lastReportedBid)
                {
                    lastReportedBid = currentBid;
                    writer.WriteLine("Highst bid is now " + lastReportedBid);
                } 
                System.Threading.Thread.Sleep(50);
            }
        }
        public void ReportStatus()
        {
            int lastHammerCount = 0;            
            while (true)
            {
                int hammerCount = AuctionStopper.hammerCount;
                if (hammerCount == 0)
                {
                    lastHammerCount = 0;
                }
                else if (hammerCount == 1 && lastHammerCount == 0)
                {
                    writer.WriteLine("Going 1.");
                    lastHammerCount = 1;
                }
                else if (hammerCount == 2 && lastHammerCount == 1)
                {
                    writer.WriteLine("Going 2.");
                    lastHammerCount = 2;
                }
                else if (hammerCount == 3 && lastHammerCount == 2)
                {
                    writer.WriteLine("Going 3.");
                    writer.WriteLine("Sold to " + CurrentBid.IPofCurrentBid + " for " + CurrentBid.GetCurrentBid());
                    writer.WriteLine("New auction starting.");
                    System.Threading.Thread.Sleep(50);
                    lastHammerCount = 0;
                    AuctionStopper.Reset();
                    CurrentBid.ResetBid();
                }                
                
            }
        }
    }
}
