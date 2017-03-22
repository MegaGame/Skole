using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    static public class AuctionStopper
    {
        static int count;
        static public int hammerCount { private set; get; }

        static public void Start()
        {
            count = 0;
            hammerCount = 0;
            Thread ASTread = new Thread(counting);
            ASTread.Start();
        }
        static public void Reset()
        {
            count = 0;
            hammerCount = 0;
        }
        static private void counting()
        {
            while (true)
            {
                if (CurrentBid.currentBid > 0)
                {
                    count++;                    
                    if (count == 10)
                    {
                        hammerCount++;
                        count = 0;
                    }
                }
                System.Threading.Thread.Sleep(1000);
            }
        }
    }
}
