using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidProject
{
    internal class Admin6BL
    {
        public string title { get; set; }
        public string description { get; set; }
        public Admin6BL (string title, string description)
        {
            this.title = title;
            this.description = description;
        }
    }
}
