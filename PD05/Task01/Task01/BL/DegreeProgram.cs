using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01.BL
{
    public class DegreeProgram
    {
        public string Title { get; set; }
        public string Duration { get; set; }
        public int AvailableSeats { get; set; }
        public List<Subject> Subjects { get; set; }

        public DegreeProgram(string title, string duration, int seats)
        {
            Title = title;
            Duration = duration;
            AvailableSeats = seats;
            Subjects = new List<Subject>();
        }

        public void AddSubject(Subject subject)
        {
            Subjects.Add(subject);
        }
    }
}
