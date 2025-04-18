using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pd04
{
    class Angle
    {
        public int degree;
        public float minute;
        public char direction;
        public Angle(int degree = 0, float minute = 0f, char direction = '\0')
        {
            this.degree = degree;
            this.minute = minute;
            this.direction = direction;
        }

        public Angle(Angle other)
        {
            this.degree = other.degree;
            this.minute = other.minute;
            this.direction = other.direction;
        }

        public void Change(int degree, float minute, char direction)
        {
            this.degree = degree;
            this.minute = minute;
            this.direction = direction;
        }

        public override string ToString()
        {
            return $"{degree}\u00b0{minute}\'{direction}";
        }


    }

}
