using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01.BL
{
    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public float FscMarks { get; set; }
        public float EcatsMarks { get; set; }
        public float Merit { get; set; }
        public List<DegreeProgram> Preferences { get; set; }
        public DegreeProgram RegisteredDegree { get; set; }
        public List<Subject> RegisteredSubjects { get; set; }
        public float Fee { get; set; }

        public Student(string name, int age, float fsc, float ecat)
        {
            Name = name;
            Age = age;
            FscMarks = fsc;
            EcatsMarks = ecat;
            Preferences = new List<DegreeProgram>();
            RegisteredSubjects = new List<Subject>();
        }

        public void CalculateMerit()
        {
            Merit = (FscMarks * 0.6f) + (EcatsMarks * 0.4f);
        }

        public bool RegisterSubject(Subject subject)
        {
            if (RegisteredDegree.Subjects.Contains(subject) && !subject.IsRegistered)
            {
                RegisteredSubjects.Add(subject);
                subject.IsRegistered = true;
                Fee += subject.Fee;
                return true;
            }
            return false;
        }
    }
}
