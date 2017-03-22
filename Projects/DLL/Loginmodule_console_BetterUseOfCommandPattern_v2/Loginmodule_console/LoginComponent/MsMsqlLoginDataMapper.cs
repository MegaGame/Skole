using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginComponent
{
    class MsMsqlLoginDataMapper:ILoginDataMapper
    {
        private string _connectString;

        public MsMsqlLoginDataMapper(string connectString)
        {
            this._connectString = connectString;
        }

        public void Create(User u)
        {
            // insert into .....
        }
    }
}
