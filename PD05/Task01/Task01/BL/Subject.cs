using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01.BL
{
    public class Subject
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int CreditHours { get; set; }
        public float Fee { get; set; }
        public bool IsRegistered { get; set; }

        public Subject(string code, string name, int creditHours, float fee)
        {
            Code = code;
            Name = name;
            CreditHours = creditHours;
            Fee = fee;
            IsRegistered = false;
        }
    }
}
