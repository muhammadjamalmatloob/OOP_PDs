using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SignUP
{
    internal class Program
    {

        public static string name;
        private static string password;
        public static char c;

        public static string menu()
        {
            Console.WriteLine(" *********************************************************");
            Console.WriteLine("                        Main Menu");
            Console.WriteLine(" *********************************************************");
            Console.WriteLine("");
            Console.WriteLine(" 1. Sign In");
            Console.WriteLine(" 2. Sign Up");
            Console.WriteLine(" 3. Exit");
            Console.Write(" Enter your choice: ");
            string choice = Console.ReadLine();
            return choice;
        }

        public static void signin_menu()
        {
            Console.Write(" Enter username: ");
            name = Console.ReadLine();
            Console.Write(" Enter password: ");
            password = Console.ReadLine();
        }

        public static bool userExist()
        {
            string u = "", p = "";
            StreamReader file = new StreamReader("data.txt");
            string line;
            int count;
            while ((line = file.ReadLine()) != null)
            {
                count = 1;
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] == ',')
                    {
                        count++;
                    }
                    else if (count == 1)
                    {
                        u += line[i];
                    }
                    else if (count == 2)
                    {
                        p += line[i];
                    }
                }
                if (u == name && p == password)
                {
                    file.Close();
                    return true;
                }
                u = "";
                p = "";
            }
            file.Close();
            return false;
        }

        public static bool isAvailable(string name)
        {
            string path = "data.txt";
            StreamReader file = new StreamReader(path);
            string line;
            string n = "";
            while ((line = file.ReadLine()) != null) 
            {
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] == ',')
                    { 
                        break; 
                    }
                    n = n + line[i];
                }
                if (n == name)
                {
                    file.Close();
                    return false;
                }
                n = "";
            }
            file.Close();
            return true;
        }

        public static void signup_logo()
        {
            Console.WriteLine(" *********************************************************");
            Console.WriteLine("                         Sign Up");
            Console.WriteLine(" *********************************************************");
            Console.WriteLine("");
        }

        public static void signin_logo()
        {
            Console.WriteLine(" *********************************************************");
            Console.WriteLine("                        Sign In");
            Console.WriteLine(" *********************************************************");
            Console.WriteLine("");
        }

        public static void addUser()
        {
            StreamWriter file = new StreamWriter("data.txt", true);
            file.WriteLine(name + "," + password);
            file.Flush();
            file.Close();
        }

        public static void signup_menu()
        {
            Console.Write(" Enter username: ");
            name = Console.ReadLine();
            Console.Write(" Enter password: ");
            password = Console.ReadLine();
        }
        public static bool isValidName(string name)
        {
            if ((name[0] < 65 || name[0] > 90) && (name[0] < 97 || name[0] > 122))
            {
                return false;
            }
            else if (name[0] == ' ' || name[0] == '\0')
            {
                return false;
            }
            for (int i = 0; i < name.Length; i++)
            {
                if ((name[i] < 65 || name[i] > 90) && (name[i] < 48 || name[i] > 57) && (name[i] < 97 || name[i] > 122))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool isValidPassword(string password)
        {
            if (password[0] == '\0')
            {
                return false;
            }
            else if (password[0] == ' ')
            {
                return false;
            }

            else if (password.Length < 8)
            {
                return false;
            }
            return true;
        }
       
        public static int Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                string choice = menu();
                while (true)
                {
                    if (choice == "1")
                    {
                        break;
                    }
                    else if (choice == "2")
                    {
                        break;
                    }
                    else if (choice == "3")
                    {
                        return 0;
                    }
                    else
                    {
                        Console.WriteLine(" Invalid Choice");
                        Console.WriteLine(" Press any key to re-enter");
                        Console.ReadLine();
                        break;
                    }
                }
                Console.Clear();
                if (choice == "1")
                {
                    while (true)
                    {
                        signin_logo();
                        signin_menu();
                        if (userExist())
                        {
                            Console.WriteLine(" Signed In Successfully");
                            Console.WriteLine(" Press any key to go back to main menu");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }
                        else
                        {
                            Console.WriteLine(" Invalid Username or Password");
                            Console.WriteLine(" Press any key to go back to main menu");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }
                    }
                }
                else if (choice == "2")
                {
                    while (true)
                    {
                        signup_logo();
                        signup_menu();
                        if (!isValidName(name))
                        {
                            Console.WriteLine(" Invalid User Name");
                            Console.WriteLine(" Press any key to go back to main menu");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }
                        else if (!isValidPassword(password))
                        {
                            Console.WriteLine(" Invalid Password");
                            Console.WriteLine(" Press any key to go back to main menu");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }
                        else if (!isAvailable(name))
                        {
                            Console.WriteLine(" User Name not available");
                            Console.WriteLine(" Press any key to go back to main menu");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }
                        else
                        {
                            Console.WriteLine(" SignedUp Successfully");
                            addUser();
                            Console.WriteLine(" Press any key to go back to main menu");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }
                    }
                }
            }
        }

        
    }

}
