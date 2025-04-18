using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidProject
{
    internal class Admin5BL
    {
        public string course_name {  get; set; }
        public string course_type {  get; set; }
        public int credit_hours {  get; set; }
        public int contact_hours {  get; set; }
        public Admin5BL(string course_name, string course_type, int credit_hours, int contact_hours)
        {
            this.course_name = course_name;
            this.course_type = course_type;
            this.credit_hours = credit_hours;
            this.contact_hours = contact_hours;
        }
    }
}
