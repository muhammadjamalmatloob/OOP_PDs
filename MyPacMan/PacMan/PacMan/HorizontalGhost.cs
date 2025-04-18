using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPacMan
{
    public class HorizontalGhost : Ghost
    {
        private string direction = "left";

        public HorizontalGhost(int x, int y) : base(x, y, 'G') { }

        public override void Move(Maze maze)
        {
            if (direction == "left")
            {
                if (maze.IsWalkable(Y, X - 1))
                {
                    MoveLeft(maze);
                    if (!maze.IsWalkable(Y, X - 1)) direction = "right";
                }
            }
            else
            {
                if (maze.IsWalkable(Y, X + 1))
                {
                    MoveRight(maze);
                    if (!maze.IsWalkable(Y, X + 1)) direction = "left";
                }
            }
        }

        

    }
}
