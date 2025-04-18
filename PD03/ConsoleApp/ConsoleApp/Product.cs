using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    class Product
    {
        public string name;
        public float price;

        public Product()
        {

        }
        public Product(string Name = null, float Price = 0.0F)
        {
            name = Name;
            price = Price;
        }

        public void ChangePrice(float Price)
        {
            price = Price;
        }
    }
}
