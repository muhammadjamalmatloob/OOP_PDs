using System;
using System.Threading;
using EZInput;
using System.IO;
using MyPacMan.UI;

namespace MyPacMan
{
    class Program
    {
        static void Main(string[] args)
        {
            GameController gameController = new GameController();
            gameController.RunGame();

        }
    }
}

