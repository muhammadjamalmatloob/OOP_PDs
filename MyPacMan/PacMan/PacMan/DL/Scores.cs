using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPacMan.DL
{
    public static class ScoreManager
    {
        private static int score = 0;

        public static int Score => score;

        public static void IncreaseScore(int points = 1)
        {
            score += points;
        }

        public static void DisplayScore()
        {
            Console.SetCursorPosition(79, 12);
            Console.WriteLine($"Score: {score}");
        }

        public static void Reset()
        {
            score = 0;
        }
    }
}
