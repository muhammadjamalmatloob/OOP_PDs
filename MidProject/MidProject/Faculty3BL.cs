using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidProject
{
    internal class Faculty3BL
    {
        public string item_name {  get; set; }
        public int quantity { get; set; }
        public string status {  get; set; }
        public DateTime request_date { get; set; }
        public Faculty3BL (string item_name, int quantity, string status, DateTime request_date)
        {
            this.item_name = item_name;
            this.quantity = quantity;
            this.status = status;
            this.request_date = request_date;
        }
        public Faculty3BL(string item_name, int quantity)
        {
            this.item_name = item_name;
            this.quantity = quantity;
        }
    }
}
