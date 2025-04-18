using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPacMan
{
    public class VerticalGhost : Ghost
    {
        private string direction = "up";

        public VerticalGhost(int x, int y) : base(x, y, 'G') { }

        public override void Move(Maze maze)
        {
            
            if (CheckPacManCollision(maze, Y, X))
            {
                return;
            }

            if (direction == "up")
            {
                if (maze.IsWalkable(Y - 1, X))
                {
                    MoveUp(maze);
                    if (!maze.IsWalkable(Y - 1, X))
                    {
                        direction = "down";
                    }
                }
                else
                {
                    direction = "down";
                }
            }
            else 
            {
                if (maze.IsWalkable(Y + 1, X))
                {
                    MoveDown(maze);
                    if (!maze.IsWalkable(Y + 1, X))
                    {
                        direction = "up";
                    }
                }
                else
                {
                    direction = "up";
                }
            }
        }

        
    }
}
