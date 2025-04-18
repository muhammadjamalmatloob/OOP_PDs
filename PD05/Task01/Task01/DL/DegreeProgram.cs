using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task01.BL;
using System.IO;

namespace Task01.DL
{
    public static class DegreeProgramDL
    {
        public static List<DegreeProgram> Programs = new List<DegreeProgram>();

        public static void LoadFromFile(string path)
        {
            if (File.Exists(path))
            {
                Programs.Clear();
                string[] lines = File.ReadAllLines(path);
                foreach (string line in lines)
                {
                    string[] data = line.Split(',');
                    DegreeProgram program = new DegreeProgram(data[0], data[1], int.Parse(data[2]));

                    // Add subjects to program
                    for (int i = 3; i < data.Length; i++)
                    {
                        Subject subject = SubjectDL.FindSubject(data[i]);
                        if (subject != null)
                            program.AddSubject(subject);
                    }

                    Programs.Add(program);
                }
            }
        }

        public static void StoreToFile(string path)
        {
            List<string> lines = new List<string>();
            foreach (DegreeProgram program in Programs)
            {
                string line = $"{program.Title},{program.Duration},{program.AvailableSeats}";
                foreach (Subject subject in program.Subjects)
                {
                    line += $",{subject.Code}";
                }
                lines.Add(line);
            }
            File.WriteAllLines(path, lines);
        }
    }
}
