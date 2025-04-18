using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidProject
{
    internal class DeapHead1BL
    {
        public string name {  get; set; }
        public string course_name { get; set; }
        public string course_type {  get; set; }
        public string term { get; set; }
        public int year { get; set; }
        public DeapHead1BL(string name, string course_name, string course_type, string term, int year)
        {
            this.name = name;
            this.course_name = course_name;
            this.course_type = course_type;
            this.term = term;
            this.year = year;
        }
    }
}
