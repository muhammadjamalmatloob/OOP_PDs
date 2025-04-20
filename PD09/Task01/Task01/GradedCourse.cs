using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{
    public class GradedCourse : Course
    {
        public GradedCourse(string course_name, int marks) : base(course_name,marks)
        {
            this.course_name = course_name;
            this.marks = marks;
            SetGrade();
        }
        public override void SetGrade()
        {
            if (marks >= 90 && marks <= 100)
            {
                grade = "12";
            }
            else if (marks >= 80)
            {
                grade = "10";
            }
            else if (marks >= 70)
            {
                grade = "7";
            }
            else if (marks >= 60)
            {
                grade = "4";
            }
            else if (marks >= 50)
            {
                grade = "02";
            }
            else if (marks >= 40)
            {
                grade = "0";
            }
            else if (marks < 40)
            {
                grade = "-3";
            }
        }
        public bool Passed()
        {
            if (grade == "0" || grade == "-3")
            {
                return false;
            }
            return true;
        }
    }
}
