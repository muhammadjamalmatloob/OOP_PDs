using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task01.DL;
using Task01.BL;

namespace Task01.UI
{
    public static class SubjectUI
    {
        public static Subject TakeSubjectInput()
        {
            Console.Write("Enter Subject Code: ");
            string code = Console.ReadLine();

            Console.Write("Enter Subject Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Credit Hours: ");
            int creditHours;
            while (!int.TryParse(Console.ReadLine(), out creditHours) || creditHours < 1)
            {
                Console.Write("Invalid input. Enter positive integer for credit hours: ");
            }

            Console.Write("Enter Subject Fee: ");
            float fee;
            while (!float.TryParse(Console.ReadLine(), out fee) || fee < 0)
            {
                Console.Write("Invalid input. Enter non-negative number for fee: ");
            }

            return new Subject(code, name, creditHours, fee);
        }

        public static void ViewSubjects()
        {
            Console.WriteLine("Available Subjects:");
            Console.WriteLine("Code\tName\tCredit Hours\tFee");
            foreach (var subject in SubjectDL.Subjects)
            {
                Console.WriteLine($"{subject.Code}\t{subject.Name}\t{subject.CreditHours}\t{subject.Fee}");
            }
        }
    }
}
