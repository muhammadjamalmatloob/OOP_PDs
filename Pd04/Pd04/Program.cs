﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pd04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }
        static string Menu()
        {
            string choice;
            Console.WriteLine("1. Add Ship");
            Console.WriteLine("2. View Ship Position");
            Console.WriteLine("3. View Ship Serial Number");
            Console.WriteLine("4. Change Ship Position");
            Console.WriteLine("5. Exit");
            Console.WriteLine("Enter your choice: ");
            choice = Console.ReadLine();
            return choice;
        }
    }
}
