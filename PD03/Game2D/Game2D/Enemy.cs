using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2D
{
    class Enemy
    {
        public int x;
        public int y;
        public Enemy(int x,int y)
        {
            this.x = x;
            this.y = y;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.SetCursorPosition(x, y);
            Console.WriteLine("(}  {)");
            Console.SetCursorPosition(x, y + 1);
            Console.WriteLine(" !()!");
            Console.SetCursorPosition(x, y + 2);
            Console.WriteLine("(****)");
            Console.SetCursorPosition(x, y + 3);
            Console.WriteLine("||  ||");
        }
        public void Erase()
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine("      ");
            Console.SetCursorPosition(x, y + 1);
            Console.WriteLine("      ");
            Console.SetCursorPosition(x, y + 2);
            Console.WriteLine("      ");
            Console.SetCursorPosition(x, y + 3);
            Console.WriteLine("      ");
        }
        public void Print()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.SetCursorPosition(x, y);
            Console.WriteLine("(}  {)");
            Console.SetCursorPosition(x, y + 1);
            Console.WriteLine(" !()!");
            Console.SetCursorPosition(x, y + 2);
            Console.WriteLine("(****)");
            Console.SetCursorPosition(x, y + 3);
            Console.WriteLine("||  ||");
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
