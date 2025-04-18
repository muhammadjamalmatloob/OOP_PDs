using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPacMan
{
    public abstract class GameEntity
    {
        public int Y { get; protected set; }
        public int X { get; protected set; }
        protected char displayChar;

        public GameEntity(int x, int y, char display)
        {
            Y = x;
            X = y;
            displayChar = display;
        }

        public virtual void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(displayChar);
        }

        public virtual void Erase(char replaceWith = ' ')
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(replaceWith);
        }

        public abstract void Move(Maze maze);
    }
}
