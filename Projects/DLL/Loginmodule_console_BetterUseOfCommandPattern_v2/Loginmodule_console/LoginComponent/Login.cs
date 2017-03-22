﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginComponent
{
    public class Login
    {
        private ILoginDataMapper _fdm;

        public Login(ILoginDataMapper fdm)
        {
            this._fdm = fdm;
        }
        
        public void CreateUser(string email, string password, string confirmPassword)
        {
            new CreateUserCommand(email, password, confirmPassword, _fdm).Execute();
        }
    }
}
