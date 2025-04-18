using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Xml.Linq;

namespace App
{
    internal class Program
    {
        static int Main(string[] args)
        {
            string choice;
            User user;
            Product product;
            bool condition;
            Logo();
            while (true)
            {
                Console.Clear();
                choice = MainMenu();
                condition = true;
                if (choice == "1")
                {
                    while (condition)
                    {
                        condition = true;
                        Console.Clear();
                        choice = AdminMenu();
                        if (choice == "1")
                        {
                            Console.Clear();
                            user = new User();
                            SignInMenu(user);
                            user.role = "Admin";
                            if (UserPresent(user))
                            {
                                while (condition)
                                {
                                    Console.Clear();
                                    choice = AdminInterface();
                                    if (choice == "1")
                                    {
                                        Console.Clear();
                                        product = new Product();
                                        Console.WriteLine(AddProduct(product));
                                        Console.ReadKey();
                                    }
                                    else if (choice == "2")
                                    {
                                        Console.Clear();
                                        ShowProducts();
                                        Console.WriteLine("Which product you want to remove?");
                                        choice = Console.ReadLine();
                                        Console.WriteLine(RemoveProduct(Convert.ToInt32(choice)));
                                        Console.ReadKey();
                                    }
                                    else if (choice == "3")
                                    {
                                        Console.Clear();
                                        Console.WriteLine(UpdateDiscount());
                                        Console.ReadKey();
                                    }
                                    else if (choice == "4")
                                    {
                                        user = new User();
                                        Console.Clear();
                                        AddAdmin(user);
                                        Console.ReadKey();
                                    }
                                    else if (choice == "5")
                                    {
                                        Console.Clear();
                                        ShowProducts();
                                        Console.WriteLine("Press any key to go back...");
                                        Console.ReadKey();
                                    }
                                    else if (choice == "6")
                                    {
                                        Console.Clear();
                                        Console.WriteLine(ViewUsers());
                                        Console.ReadKey();
                                    }
                                    else if (choice == "7")
                                    {
                                        condition = false;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid Choice.\nPress any key..");
                                        Console.ReadKey();
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("No Such Admin Present");
                                Console.ReadKey();
                            }
                        }
                        else if (choice == "2")
                        {
                            condition = false;
                        }
                        else
                        {
                            Console.WriteLine("Invalid Choice.\nPress any key..");
                            Console.ReadKey();
                        }
                    }


                }
                else if (choice == "2")
                {
                    while (condition)
                    {
                        Console.Clear();
                        choice = UserMenu();
                        condition = true;
                        if (choice == "1")
                        {
                            Console.Clear();
                            user = new User();
                            SignInMenu(user);
                            user.role = "Customer";
                            if (UserPresent(user))
                            {
                                Console.Clear();
                                choice = UserInterface();
                                if (choice == "1")
                                { }
                                else if (choice == "2")
                                { }
                                else if (choice == "3")
                                { }
                                else if (choice == "4")
                                { }
                                else if (choice == "5")
                                { }
                                else if (choice == "6")
                                { }
                                else if (choice == "7")
                                { }
                                else
                                { }
                            }
                            else
                            {
                                Console.WriteLine("No Such Customer Present");
                                Console.ReadKey();
                            }
                        }
                        else if (choice == "2")
                        {
                            while (condition)
                            {
                                Console.Clear();
                                user = new User();
                                SignUpMenu(user);
                                user.role = "Customer";
                                if (UserNameValid(user.name))
                                {
                                    if (IsValidPassword(user.password))
                                    {
                                        AddUser(user);
                                    }
                                }
                                Console.WriteLine("Press any key to go to back...");
                                Console.ReadKey();
                                condition = false;
                            }
                        }
                        else if (choice == "3")
                        {
                            condition = true;
                        }
                        else
                        {
                            Console.WriteLine("Invalid Choice.\nPress any key...");
                            Console.ReadKey();
                        }
                    }

                }
                else if (choice == "3")
                {
                    return 0;
                }
                else
                {
                    Console.WriteLine("Invalid Choice.\nPress any key...");
                    Console.ReadKey();
                }
            }
        }
        static void Logo()
        {
            Thread.Sleep(500);
            Console.WriteLine("***************************************************");
            Thread.Sleep(100);
            Console.WriteLine("          Restaurant Management System             ");
            Thread.Sleep(500);
            Console.WriteLine("***************************************************");
            Console.WriteLine("\n\n                     Loading.....                  ");
            Thread.Sleep(2000);
        }
        static void SignUpMenu(User user)
        {
            Console.WriteLine("**********************************");
            Console.WriteLine("*             SignUp             *");
            Console.WriteLine("**********************************\n");
            Console.Write("Enter username:");
            user.name = Console.ReadLine();
            Console.Write("Enter password:");
            user.password = Console.ReadLine();
        }

        static void SignInMenu(User user)
        {
            Console.WriteLine("**********************************");
            Console.WriteLine("*             SignIn             *");
            Console.WriteLine("**********************************\n");
            Console.Write("Enter username:");
            user.name = Console.ReadLine();
            Console.Write("Enter password:");
            user.password = Console.ReadLine();
        }
        static string MainMenu()
        {
            string choice;
            Console.WriteLine("**********************************");
            Console.WriteLine("*            Main Menu           *");
            Console.WriteLine("**********************************\n");
            Console.WriteLine("1. Admin");
            Console.WriteLine("2. Customer");
            Console.WriteLine("3. Exit");
            Console.WriteLine("Enter your choice: ");
            choice = Console.ReadLine();
            return choice;
        }

        static string AdminMenu()
        {
            string choice;
            Console.WriteLine("**********************************");
            Console.WriteLine("*           Admin Menu           *");
            Console.WriteLine("**********************************\n");
            Console.WriteLine("1. Sign In");
            Console.WriteLine("2. Main Menu");
            Console.WriteLine("Enter your choice: ");
            choice = Console.ReadLine();
            return choice;
        }
        static string UserMenu()
        {
            string choice;
            Console.WriteLine("**********************************");
            Console.WriteLine("*            User Menu           *");
            Console.WriteLine("**********************************\n");
            Console.WriteLine("1. Sign In");
            Console.WriteLine("2. Sign Up");
            Console.WriteLine("3. Main Menu");
            Console.WriteLine("Enter your choice: ");
            choice = Console.ReadLine();
            return choice;
        }

        static string AddUser(User user)
        {
            if (user.role == "Admin")
            {
                StreamWriter file = new StreamWriter("Admin.txt", true);
                file.WriteLine(user.name + "," + user.password);
                file.Flush();
                file.Close();
                return "Admin added successfully...";
            }
            else
            {
                StreamWriter file = new StreamWriter("User.txt", true);
                file.WriteLine(user.name + "," + user.password + "," + user.balance);
                file.Flush();
                file.Close();
                return "Signed Up successfully...";
            }

        }

        static bool UserNameValid(string name)
        {
            if (name == "")
            {
                Console.WriteLine("Username can't be empty");
                return false;
            }
            else if (name[0] > 47 && name[0] < 58)
            {
                Console.WriteLine("Username can't start with a number");
                return false;
            }
            foreach (char i in name)
            {
                if ((i < 48 || i > 57) && (i < 65 || i > 90) && (i < 97 || i > 122))
                {
                    Console.WriteLine("Username should contain only alphabets and numbers");
                    return false;
                }

            }
            if (!CustomerNameAvailable(name))
            {
                Console.WriteLine("User with this name already exists");
                return false;
            }
            return true;
        }

        static float Tax(Product product, float percent)
        {
            float tax;
            tax = product.price * percent / 100;
            return tax;
        }
        static string AdminInterface()
        {
            string choice;
            Console.WriteLine("**********************************");
            Console.WriteLine("*              Admin             *");
            Console.WriteLine("**********************************\n");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Remove Product");
            Console.WriteLine("3. Change Discount");
            Console.WriteLine("4. Add Admin");
            Console.WriteLine("5. View All Products");
            Console.WriteLine("6. View All Users");
            Console.WriteLine("7. LogOut");
            Console.WriteLine("Enter your choice: ");
            choice = Console.ReadLine();
            return choice;
        }
        static string UserInterface()
        {
            string choice;
            Console.WriteLine("**********************************");
            Console.WriteLine("*              User              *");
            Console.WriteLine("**********************************\n");
            Console.WriteLine("1. Buy A Product");
            Console.WriteLine("2. Offers");
            Console.WriteLine("3. View Balance");
            Console.WriteLine("4. Update Balance");
            Console.WriteLine("5. View Bought Items");
            Console.WriteLine("6. Delete Account");
            Console.WriteLine("7. LogOut");
            Console.WriteLine("Enter your choice: ");
            choice = Console.ReadLine();
            return choice;
        }


        static bool CustomerNameAvailable(string name)
        {
            StreamReader file = new StreamReader("User.txt");
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
        static bool IsValidPassword(string password)
        {
            if (password[0] == '\0')
            {
                Console.WriteLine("Password can't be empty");
                return false;
            }

            else if (password.Length < 8)
            {
                Console.WriteLine("Password should contain at least 8 characters");
                return false;
            }
            foreach (char c in password)
            {
                if (c == ' ')
                {
                    Console.WriteLine("Password can't contain spaces");
                    return false;
                }
            }
            return true;
        }
        static bool UserPresent(User user)
        {
            string u = "", p = "";
            if (user.role == "Admin")
            {
                const string path = "Admin.txt";
                StreamReader file = new StreamReader(path);
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
                    if (u == user.name && p == user.password)
                    {
                        file.Close();
                        return true;
                    }
                    u = "";
                    p = "";
                }
                file.Close();
            }
            else
            {
                const string path = "User.txt";
                StreamReader file = new StreamReader(path);
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
                    if (u == user.name && p == user.password)
                    {
                        file.Close();
                        return true;
                    }
                    u = "";
                    p = "";
                }
                file.Close();
            }
            return false;

        }
        static string AddProduct(Product product)
        {
            Console.WriteLine("Enter Product Name: ");
            product.name = Console.ReadLine();
            Console.WriteLine("Enter Product Price: ");
            product.price = Convert.ToSingle(Console.ReadLine());
            StreamWriter file = new StreamWriter("Product.txt", true);
            file.WriteLine(product.name + "," + product.price);
            file.Flush();
            file.Close();
            return "Product added successfully...";
        }
        static string getfield(string record, int num)
        {
            int comma = 1;
            string field = "";
            foreach (char c in record)
            {
                if (c == ',')
                {
                    comma++;
                }
                else if (comma == num)
                {
                    field += c;
                }
            }
            return field;
        }
        static void ShowProducts()
        {
            int x = 1, y = 1;
            StreamReader file = new StreamReader("Product.txt");
            string line;
            Console.SetCursorPosition(x, y);
            Console.WriteLine("No.");
            Console.SetCursorPosition(x + 10, y);
            Console.WriteLine("Product Name");
            Console.SetCursorPosition(x + 40, y);
            Console.WriteLine("Price");
            while ((line = file.ReadLine()) != null)
            {
                y++;
                Console.SetCursorPosition(x, y);
                Console.WriteLine(y-1);
                Console.SetCursorPosition(x + 10, y);
                Console.WriteLine(getfield(line, 1));
                Console.SetCursorPosition(x + 40, y);
                Console.WriteLine(getfield(line, 2));
            }
            file.Close();
        }
        static void CleanFile(string FilePath)
        {
            StreamWriter file = new StreamWriter(FilePath, false);
            file.Write(string.Empty);
            file.Flush();
            file.Close();
        }
        static string RemoveProduct(int num)
        {
            StreamReader file = new StreamReader("Product.txt");
            string line;
            int count = 0;
            while ((line = file.ReadLine()) != null)
            {
                AppendToFile("Temp.txt", line);
            }
            file.Close();
            CleanFile("Product.txt");
            StreamReader file2 = new StreamReader("Temp.txt");
            while ((line = file2.ReadLine()) != null)
            {
                count++;
                if (count != num)
                {
                    AppendToFile("Product.txt", line);
                }
            }
            file2.Close();
            //CleanFile("Temp.txt");
            return "Product removed successfully";
        }
        static void AppendToFile(string FilePath,string line)
        {
            StreamWriter file = new StreamWriter(FilePath,true);
            file.WriteLine(line);
	    file.flush();
            file.Close();
        }
        static int Discount()
        {
            StreamReader file = new StreamReader("Disc.txt");
            string line;
            line = file.ReadLine();
            return Convert.ToInt32(line);
        }
        static string UpdateDiscount()
        {
            int disc;
            Console.WriteLine("Previous discount(%): " + Discount());
            Console.WriteLine("Enter new discount value(%): ");
            disc = Convert.ToInt32(Console.ReadLine());
            CleanFile("Disc.txt");
            AppendToFile("Disc.txt",Convert.ToString(disc));
            return "Discount updated successfully...";
        }
        static void AddAdmin(User user)
        {
            Console.WriteLine("Enter username: ");
            user.name = Console.ReadLine();
            Console.WriteLine("Enter password: ");
            user.password = Console.ReadLine();
            user.role = "Admin";
            Console.WriteLine(AddUser(user));
        }
        static string ViewUsers()
        {
            int x = 1, y = 1;
            StreamReader file = new StreamReader("User.txt");
            string line;
            Console.SetCursorPosition(x, y);
            Console.WriteLine("No.");
            Console.SetCursorPosition(x + 10, y);
            Console.WriteLine("User Name");
            Console.SetCursorPosition(x + 40, y);
            Console.WriteLine("Balance");
            while ((line = file.ReadLine()) != null)
            {
                y++;
                Console.SetCursorPosition(x, y);
                Console.WriteLine(y - 1);
                Console.SetCursorPosition(x + 10, y);
                Console.WriteLine(getfield(line, 1));
                Console.SetCursorPosition(x + 40, y);
                Console.WriteLine(getfield(line, 3));
            }
            file.Close();
            return "Press any key to go back...";
        }
    }
}

