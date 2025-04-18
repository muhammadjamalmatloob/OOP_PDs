using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPacMan
{
    public class RandomGhost : Ghost
    {
        private Random random;

        public RandomGhost(int x, int y) : base(x, y, 'G')
        {
            random = new Random();
        }

        public override void Move(Maze maze)
        {
            
            if (CheckPacManCollision(maze, Y, X))
            {
                return;
            }

            int direction = random.Next(4); 

            switch (direction)
            {
                case 0: 
                    if (maze.IsWalkable(Y - 1, X))
                    {
                        MoveUp(maze);
                    }
                    break;
                case 1: 
                    if (maze.IsWalkable(Y, X + 1))
                    {
                        MoveRight(maze);
                    }
                    break;
                case 2: 
                    if (maze.IsWalkable(Y + 1, X))
                    {
                        MoveDown(maze);
                    }
                    break;
                case 3: 
                    if (maze.IsWalkable(Y, X - 1))
                    {
                        MoveLeft(maze);
                    }
                    break;
            }
        }

        
    }
}
