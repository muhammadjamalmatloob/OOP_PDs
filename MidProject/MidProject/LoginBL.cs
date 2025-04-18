using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidProject
{
    internal class LoginBL
    {
        public string username { get; set; }
        public string password { get; set; }
        public string role { get; set; }
        public LoginBL(string username, string password, string role)
        {
            this.username = username;
            this.password = password;
            this.role = role;
        }
    }
}
