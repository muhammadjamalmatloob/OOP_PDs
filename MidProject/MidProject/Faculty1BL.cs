using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace MidProject
{
    internal class Faculty1BL
    {
        public string course_name {  get; set; }
        public string course_type { get; set; }
        public string term {  get; set; }
        public int year { get; set; }
        public Faculty1BL (string course_name, string course_type, string term, int year)
        {
            this.course_name = course_name;
            this.course_type = course_type;
            this.term = term;
            this.year = year;
        }
    }
}
