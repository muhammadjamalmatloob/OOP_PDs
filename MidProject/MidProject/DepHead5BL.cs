using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MidProject
{
    internal class DepHead5BL
    {
        public string name {  get; set; }
        public string item_name { get; set; }
        public int quamtity { get; set; }
        public DateTime request_date { get; set; }
        
        public DepHead5BL (string name,string item_name, int quantity, DateTime request_date)
        {
            this.name = name;
            this.item_name = item_name;
            this.quamtity = quantity;
            this.request_date = request_date;
            
        }
        

    }
}
