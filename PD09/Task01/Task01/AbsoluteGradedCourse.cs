using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{
    public class AbsoluteGradedCourse : Course
    {
        public AbsoluteGradedCourse(string course_name, int marks) : base(course_name, marks)
        {
            this.course_name = course_name;
            this.marks = marks;
            SetGrade();
        }
        public override void SetGrade()
        {
            if (marks >= 90 && marks <= 100){ grade = "A+";}
            else if (marks >= 80){ grade = "A";}
            else if (marks >= 70){ grade = "B";}
            else if (marks >= 60){ grade = "C";}
            else if (marks >= 50){ grade = "D";}
            else if (marks < 50){ grade = "F";}
        }
        public bool Passed()
        {
            if (grade == "F")
            {
                return false;
            }
            return true;
        }
    }
}
