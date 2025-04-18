using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EZInput;

namespace Game2D
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Maze();
            Console.CursorVisible = false;
            Enemy enemy1 = new Enemy(3, 1);
            Enemy enemy2 = new Enemy(16, 11);
            Enemy enemy3 = new Enemy(60, 17);
            Player player = new Player(2, 17);
            bool c1 = true;
            bool c2 = true;
            bool c3 = true;
            while (true)
            {
                Thread.Sleep(100);
                if (Keyboard.IsKeyPressed(Key.RightArrow))
                {
                    player.MoveRight();
                }
                else if (Keyboard.IsKeyPressed(Key.LeftArrow))
                {
                    player.MoveLeft();
                }
                else if (Keyboard.IsKeyPressed(Key.UpArrow))
                {
                    player.MoveUp();
                }
                else if (Keyboard.IsKeyPressed(Key.DownArrow))
                {
                    player.MoveDown();
                }
                if (c1)
                {
                    enemy1.MoveDown();
                }
                else
                {
                    enemy1.MoveUp();
                }
                if (c2)
                { 
                    enemy2.MoveRight();
                }
                else
                {
                    enemy2.MoveLeft();
                }
                if (c3)
                { 
                    enemy3.MoveUp();
                }
                else
                {
                    enemy3.MoveDown();
                }
                if (enemy1.y == 1)
                {
                    c1 = true;
                }
                if (enemy1.y == 11)
                {
                    c1 = false;
                }
                if (enemy2.x == 16)
                {
                    c2 = true;
                }
                if (enemy2.x == 49)
                {
                    c2 = false;
                }
                if (enemy3.y == 17)
                {
                    c3 = true;
                }
                if (enemy3.y == 7)
                { 
                    c3 = false;
                }
            }
        }
        static void Maze()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("#######################################################################");
            Console.WriteLine("##                                                         *         ##");
            Console.WriteLine("##                                                         *         ##");
            Console.WriteLine("##                                                         *         ##");
            Console.WriteLine("##                                                         *         ##");
            Console.WriteLine("##                                                         *         ##");
            Console.WriteLine("##              #######################################################");
            Console.WriteLine("##                                                                   ##");
            Console.WriteLine("##                                                                   ##");
            Console.WriteLine("##                                                                   ##");
            Console.WriteLine("##                                                                   ##");
            Console.WriteLine("##                                                                   ##");
            Console.WriteLine("##                                                                   ##");
            Console.WriteLine("##                                                                   ##");
            Console.WriteLine("##                                                                   ##");
            Console.WriteLine("#######################################################              ##");
            Console.WriteLine("##                                                                   ##");
            Console.WriteLine("##                                                                   ##");
            Console.WriteLine("##                                                                   ##");
            Console.WriteLine("##                                                                   ##");
            Console.WriteLine("##                                                                   ##");
            Console.WriteLine("#######################################################################");
        }
        
    }
}
