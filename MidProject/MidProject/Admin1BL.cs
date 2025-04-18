using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidProject
{
    internal class Admin1BL
    {
        public string username { get; set; }
        public string name {  get; set; }
        public string email { get; set; }
        public string contact { get; set; }
        public string designation { get; set; }
        public string research_area { get; set; }
        public int total_teaching_hours {  get; set; }
        public Admin1BL(string Username,string Name, string Email, string Contact, string Designation, string Reasearch_Area,int Teaching_Hours)
        {
            this.username = Username;
            this.name = Name;
            this.email = Email;
            this.contact = Contact;
            this.designation = Designation;
            this.research_area = Reasearch_Area;
            this.total_teaching_hours = Teaching_Hours;
        }
        public Admin1BL()
        {

        }
    }
}
