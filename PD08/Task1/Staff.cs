﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class Staff:Person
    {
        private string school;
        private double pay;

        public Staff(string name,string address,string school, double pay):base(name,address)
        {
            this.school = school;
            this.pay = pay;
        }
        public string getSchool()
        {
            return school;
        }
        public void setSchool(string school)
        {
            this.school=school;
        }
        public double getPay()
        {
            return pay;
        }
        public void setPay(double pay)
        {
            if (pay < 0)
            {
                pay = 0;
            }
            this.pay = pay;
        }
        public new string toString()
        {
            string person =base.toString();
            return $"Staff[{person}, school={school},fee={pay}]";
        }
    }
}
