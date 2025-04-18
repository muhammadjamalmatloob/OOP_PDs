using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace App
{
    class User
    {
        public string name;
        public string password;
        public string balance; 
        public string role;

        public User()
        { 
        }

        public User(User user)
        {
            name = user.name;
            password = user.password;
            role = user.role;
        }

        public User(string Name = null , string Password = null, string Role = null, string Balance = null)
        {
            name = Name;
            password = Password;
            role = Role;
            balance = Balance;
        }
        public void ChangePassword(string Password)
        {
            password = Password;
        }
    }
}
