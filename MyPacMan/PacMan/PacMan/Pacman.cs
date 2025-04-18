using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPacMan.DL;

namespace MyPacMan
{
    
        public class PacMan : GameEntity
        {
            public PacMan(int x, int y) : base(x, y, 'P') { }

            public override void Move(Maze maze)
            {

            }

            public void MoveUp(Maze maze)
            {
                if (maze.IsWalkable(Y - 1, X))
                {
                    Erase();
                    Y--;
                    CheckPellet(maze);
                    Draw();
                }
            }

            public void MoveDown(Maze maze)
            {
                if (maze.IsWalkable(Y + 1, X))
                {
                    Erase();
                    Y++;
                    CheckPellet(maze);
                    Draw();
                }
            }

            public void MoveLeft(Maze maze)
            {
                if (maze.IsWalkable(Y, X - 1))
                {
                    Erase();
                    X--;
                    CheckPellet(maze);
                    Draw();
                }
            }

            public void MoveRight(Maze maze)
            {
                if (maze.IsWalkable(Y, X + 1))
                {
                    Erase();
                    X++;
                    CheckPellet(maze);
                    Draw();
                }
            }

            private void CheckPellet(Maze maze)
            {
                if (maze.HasPellet(Y, X))
                {
                    ScoreManager.IncreaseScore();
                    maze.ClearPellet(Y, X);
                }
            }


        }
    }

