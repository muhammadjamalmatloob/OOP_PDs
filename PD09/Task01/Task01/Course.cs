using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{
    public abstract class Course
    {
        protected string course_name;
        protected int marks;
        protected string grade;
        public Course(string course_name, int marks)
        {
            this.course_name = course_name;
            this.marks = marks;
            SetGrade();
        }
        public virtual void SetGrade()
        {
            
        }
        public string getCourseName()
        {
            return course_name;
        }
        public int getMarks()
        {
            return marks;
        }
        public string getGrade()
        {
            return grade;
        }
        public void setCourseName(string course_name)
        {
            this.course_name = course_name;
        }
        public void setMarks(int marks)
        {
            this.marks = marks; 
        }
        public override string ToString()
        {
            return $"{course_name},{marks},{grade}";
        }
    }
}
