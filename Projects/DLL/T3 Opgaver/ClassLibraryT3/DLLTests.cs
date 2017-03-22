using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryT3
{
    public class DLLTests
    {
        public int liv = 9;
        public string CatLives(int liv)
        {
            this.liv = liv;
            return "katten har " + liv + " tilbage";
        }

    }
}
