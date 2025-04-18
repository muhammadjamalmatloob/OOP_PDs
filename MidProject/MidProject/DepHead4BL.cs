using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidProject
{
    internal class DepHead4BL
    {
        public string name {  get; set; }
        public string role_name {  get; set; }
        public string term { get; set; }
        public int year { get; set; }
        public DepHead4BL(string name,string role_name, string term, int year)
        {
            this.name = name;
            this.role_name = role_name;
            this.term = term;
            this.year = year;
        }
    }
}
