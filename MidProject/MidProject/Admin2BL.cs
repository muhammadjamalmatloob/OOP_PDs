using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidProject
{
    internal class Admin2BL
    {
        public string username {  get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string role {  get; set; }
        public string name { get; set; }
        public string contact { get; set; }
        public string research_area {  get; set; }
        public string designation { get; set; }
        public Admin2BL(string username,string password, string email, string role, string name, string contact, string research_area,string designation) 
        {
            this.username = username;
            this.password = password;
            this.email = email;
            this.role = role;
            this.name = name;
            this.contact = contact;
            this.research_area = research_area;
            this.designation = designation;
        }
        public Admin2BL (string username, string password, string email, string role)
        {
            this.username = username;
            this.password = password;
            this.email = email;
            this.role = role;
        }
    }
}
