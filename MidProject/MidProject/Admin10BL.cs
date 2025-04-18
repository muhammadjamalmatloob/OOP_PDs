using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidProject
{
    internal class Admin10BL
    {
        public string term {  get; set; }
        public int year {  get; set; }
        public Admin10BL(string term, int year)
        {
            this.term = term;
            this.year = year;
        }
    }
}
