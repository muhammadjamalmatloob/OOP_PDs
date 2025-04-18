using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Game2D
{
    class ConsoleHelper
    {
        private char[,] buffer;

        public ConsoleHelper(int width, int height)
        {
            buffer = new char[width, height];
        }

        public void Write(int x, int y, char c)
        {
            buffer[x, y] = c;
            Console.SetCursorPosition(x, y);
            Console.Write(c);
        }

        public char GetCharacterAt(int x, int y)
        {
            return buffer[x, y];
        }
    }
}
