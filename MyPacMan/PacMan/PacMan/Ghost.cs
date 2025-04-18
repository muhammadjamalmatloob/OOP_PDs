using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPacMan
{
    public abstract class Ghost : GameEntity
    {
        protected char previousCell;

        public Ghost(int x, int y, char display) : base(x, y, display)
        {
            previousCell = ' ';
        }

        protected bool CheckPacManCollision(Maze maze, int newX, int newY)
        {
            return maze.GetCell(newX, newY) == 'P';
        }

        
        protected void MoveUp(Maze maze)
        {
            Erase(previousCell);
            X--;
            previousCell = maze.GetCell(X, Y);
            Draw();
        }

        protected void MoveRight(Maze maze)
        {
            Erase(previousCell);
            Y++;
            previousCell = maze.GetCell(X, Y);
            Draw();
        }

        protected void MoveDown(Maze maze)
        {
            Erase(previousCell);
            X++;
            previousCell = maze.GetCell(X, Y);
            Draw();
        }

        protected void MoveLeft(Maze maze)
        {
            Erase(previousCell);
            Y--;
            previousCell = maze.GetCell(X, Y);
            Draw();
        }
    }
}
