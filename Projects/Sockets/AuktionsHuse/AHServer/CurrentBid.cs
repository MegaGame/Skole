using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    static public class CurrentBid
    {
        static public int currentBid {  get; private set; }
        static public string IPofCurrentBid { get; private set; }
        static public string GetCurrentBid()
        {
            return currentBid.ToString();
        }
        static public bool SetCurrentBid(int bid, string IPofBid)
        {
            if (bid > currentBid)
            {
                currentBid = bid;
                IPofCurrentBid = IPofBid;
                return true;
            }
            return false;
            
        }
        static public void ResetBid()
        {
            currentBid = 0;
        }
    }    
}
