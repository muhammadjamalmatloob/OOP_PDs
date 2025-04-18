using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidProject
{
    internal class DepHead3BL
    {
        public string name { get; set; }
        public string room_name { get; set; }
        public string room_type { get; set; }
        public int reserved_hours { get; set; }
        public string term { get; set; }
        public int year { get; set; }
        public DepHead3BL (string name, string room_name, string room_type, int reserved_hours, string term, int year)
        {
            this.name = name;
            this.room_name = room_name;
            this.room_type = room_type;
            this.reserved_hours = reserved_hours;
            this.term = term;
            this.year = year;
        }
    }
}
