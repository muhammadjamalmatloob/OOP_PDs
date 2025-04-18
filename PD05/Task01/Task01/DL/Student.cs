using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Task01.BL;

namespace Task01.DL
{
    public static class StudentDL
    {
        public static List<Student> Students = new List<Student>();

        public static void LoadFromFile(string path)
        {
            if (File.Exists(path))
            {
                Students.Clear();
                string[] lines = File.ReadAllLines(path);
                foreach (string line in lines)
                {
                    string[] data = line.Split(',');
                    Student student = new Student(data[0], int.Parse(data[1]), float.Parse(data[2]), float.Parse(data[3]));
                    student.CalculateMerit();

                    
                    for (int i = 4; i < data.Length - 2; i++)
                    {
                        DegreeProgram program = DegreeProgramDL.Programs.Find(p => p.Title == data[i]);
                        if (program != null)
                            student.Preferences.Add(program);
                    }

                    
                    if (data[data.Length - 2] != "null")
                    {
                        student.RegisteredDegree = DegreeProgramDL.Programs.Find(p => p.Title == data[data.Length - 2]);
                    }

                    Students.Add(student);
                }
            }
        }

        public static void StoreToFile(string path)
        {
            List<string> lines = new List<string>();
            foreach (Student student in Students)
            {
                string line = $"{student.Name},{student.Age},{student.FscMarks},{student.EcatsMarks}";

                
                foreach (DegreeProgram pref in student.Preferences)
                {
                    line += $",{pref.Title}";
                }

                
                line += $",{(student.RegisteredDegree != null ? student.RegisteredDegree.Title : "null")},{student.Fee}";

                lines.Add(line);
            }
            File.WriteAllLines(path, lines);
        }
    }
