using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginComponent
{
    static class Helper
    {
        public static void chkEmail(string email)
        { }
        public static void chkPassword(string password)
        {
            if (password == null)
                throw new Exception("Password is null");
            if (password.Length < 6)
                throw new Exception("Password is too short");
        }

        public static string HashPassword(string password)
        {
            return "dkilsrckf";
        }
    }
}
