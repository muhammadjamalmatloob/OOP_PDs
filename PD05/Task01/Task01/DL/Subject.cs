using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task01.BL;
using System.IO;

namespace Task01.DL
{
    public static class SubjectDL
    {
        public static List<Subject> Subjects = new List<Subject>();

        public static void LoadFromFile(string path)
        {
            if (File.Exists(path))
            {
                Subjects.Clear();
                string[] lines = File.ReadAllLines(path);
                foreach (string line in lines)
                {
                    string[] data = line.Split(',');
                    Subject subject = new Subject(data[0], data[1], int.Parse(data[2]), float.Parse(data[3]));
                    Subjects.Add(subject);
                }
            }
        }

        public static void StoreToFile(string path)
        {
            List<string> lines = new List<string>();
            foreach (Subject subject in Subjects)
            {
                lines.Add($"{subject.Code},{subject.Name},{subject.CreditHours},{subject.Fee}");
            }
            File.WriteAllLines(path, lines);
        }

        public static Subject FindSubject(string code)
        {
            return Subjects.Find(s => s.Code == code);
        }
    }
}
