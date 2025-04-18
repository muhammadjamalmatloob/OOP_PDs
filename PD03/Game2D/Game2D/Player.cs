using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2D
{
    class Player
    {
        public int x;
        public int y;
        public Player(int x, int y)
        {
            this.x = x;
            this.y = y;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(x, y);
            Console.WriteLine("<@@>");
            Console.SetCursorPosition(x, y + 1);
            Console.WriteLine("####");
            Console.SetCursorPosition(x, y + 2);
            Console.WriteLine("|  |");
        }
        public void Erase()
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine("    ");
            Console.SetCursorPosition(x, y + 1);
            Console.WriteLine("    ");
            Console.SetCursorPosition(x, y + 2);
            Console.WriteLine("    ");
        }
        public void Print()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(x, y);
            Console.WriteLine("<@@>");
            Console.SetCursorPosition(x, y + 1);
            Console.WriteLine("####");
            Console.SetCursorPosition(x, y + 2);
            Console.WriteLine("|  |");
        }
        public void MoveLeft()
        {
            Erase();
            x--;
            Print();
        }
        public void MoveRight()
        {
            Erase();
            x++;
            Print();
        }
        public void MoveUp()
        {
            Erase();
            y--;
            Print();
        }
        public void MoveDown()
        {
            Erase();
            y++;
            Print();
        }
    }
}
