using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{
    public class Project
    {
        private string name;
        private AbsoluteGradedCourse c1;
        private AbsoluteGradedCourse c2;
        private GradedCourse c3;
        private GradedCourse c4;
        public Project( AbsoluteGradedCourse c1, AbsoluteGradedCourse c2, GradedCourse c3, GradedCourse c4)
        {
            this.c1 = c1;
            this.c2 = c2;
            this.c3 = c3;
            this.c4 = c4;
        }
        public bool Passed()
        {
            int n = 0;
            if (c1.Passed())
            {
                n++;
            }
            if (c2.Passed())
            {
                n++;
            }
            if (c3.Passed())
            {
                n++;
            }
            if (c4.Passed())
            {
                n++;
            }
            return n >= 3;
        }
        public void setName(string name)
        {
            this.name = name;
        }
    }
}
