using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidProject
{
    internal class Admin9BL
    {
        public string room_name { get; set; }
        public string room_type { get; set; }
        public int capacity { get; set; }
        public Admin9BL(string room_name, string room_type, int capacity)
        {
            this.room_name = room_name;
            this.room_type = room_type;
            this.capacity = capacity;
        }
    }
}
