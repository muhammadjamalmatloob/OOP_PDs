using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidProject
{
    internal class DepHead2BL
    {
        public string name {  get; set; }
        public string title {  get; set; }
        public string term {  get; set; }
        public int year { get; set; } 
        public int supervision_hours { get; set; }
        public DepHead2BL(string name, string title, string term, int year, int supervision_hours)
        {
            this.title = title;
            this.name = name;
            this.term = term;
            this.year = year;
            this.supervision_hours = supervision_hours;
        }
    }
}
