using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidProject
{
    internal class Faculty2BL
    {
        public string title {  get; set; }
        public string description { get; set; }
        public string term { get; set; }
        public int year { get; set; }
        public int reserved_hours { get; set; }
        public Faculty2BL(string title, string description, string term, int year, int reserved_hours)
        {
            this.title = title;
            this.description = description;
            this.term = term;
            this.year = year;
            this.reserved_hours = reserved_hours;
        }
    }
}
