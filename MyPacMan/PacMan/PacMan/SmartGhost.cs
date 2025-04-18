using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPacMan
{
    public class SmartGhost : Ghost
    {
        
        private const double DistanceWeight = 0.7;
        private const double RandomWeight = 0.3;

        private Random random = new Random();
        private Direction lastDirection = Direction.None;

        public SmartGhost(int x, int y) : base(x, y, 'G') { }

        public override void Move(Maze maze)
        {
            if (CheckPacManCollision(maze, X, Y))
                return;

            
            int targetX, targetY;
            FindPacMan(maze, out targetX, out targetY);

            if (targetX != -1) 
            {
                MoveIntelligently(maze, targetX, targetY);
            }
            else 
            {
                MoveRandomly(maze);
            }
        }

        private void FindPacMan(Maze maze, out int targetX, out int targetY)
        {
            targetX = -1;
            targetY = -1;

            
            int scanRadius = 10;
            int minX = Math.Max(0, X - scanRadius);
            int maxX = Math.Min(maze.Height - 1, X + scanRadius);
            int minY = Math.Max(0, Y - scanRadius);
            int maxY = Math.Min(maze.Width - 1, Y + scanRadius);

            for (int x = minX; x <= maxX; x++)
            {
                for (int y = minY; y <= maxY; y++)
                {
                    if (maze.GetCell(x, y) == 'P')
                    {
                        targetX = x;
                        targetY = y;
                        return;
                    }
                }
            }
        }

        private void MoveIntelligently(Maze maze, int targetX, int targetY)
        {
            
            var moves = new System.Collections.Generic.List<MoveOption>();

            if (maze.IsWalkable(X - 1, Y)) 
                moves.Add(new MoveOption(Direction.Up,
                    CalculateScore(X - 1, Y, targetX, targetY, Direction.Up)));

            if (maze.IsWalkable(X + 1, Y)) 
                moves.Add(new MoveOption(Direction.Down,
                    CalculateScore(X + 1, Y, targetX, targetY, Direction.Down)));

            if (maze.IsWalkable(X, Y - 1)) 
                moves.Add(new MoveOption(Direction.Left,
                    CalculateScore(X, Y - 1, targetX, targetY, Direction.Left)));

            if (maze.IsWalkable(X, Y + 1)) 
                moves.Add(new MoveOption(Direction.Right,
                    CalculateScore(X, Y + 1, targetX, targetY, Direction.Right)));

            if (moves.Count == 0) return;

            
            moves.Sort((a, b) => b.Score.CompareTo(a.Score));

            
            Direction chosenDirection = moves.Count > 1 && random.NextDouble() < 0.2
                ? moves[1].Direction 
                : moves[0].Direction; 

            ExecuteMove(maze, chosenDirection);
            lastDirection = chosenDirection;
        }

        private double CalculateScore(int newX, int newY, int targetX, int targetY, Direction direction)
        {
            
            double distanceScore = 1.0 / (1 + Math.Abs(newX - targetX) + Math.Abs(newY - targetY));

            
            double directionScore = direction == lastDirection ? 0.2 : 0;

            
            double randomScore = random.NextDouble() * 0.1;

            return DistanceWeight * distanceScore +
                   (1 - DistanceWeight - RandomWeight) * directionScore +
                   RandomWeight * randomScore;
        }

        private void MoveRandomly(Maze maze)
        {
           
            var directions = new System.Collections.Generic.List<Direction>();

            if (maze.IsWalkable(X - 1, Y)) directions.Add(Direction.Up);
            if (maze.IsWalkable(X + 1, Y)) directions.Add(Direction.Down);
            if (maze.IsWalkable(X, Y - 1)) directions.Add(Direction.Left);
            if (maze.IsWalkable(X, Y + 1)) directions.Add(Direction.Right);

            if (directions.Count > 0)
            {
                int index = random.Next(directions.Count);
                ExecuteMove(maze, directions[index]);
            }
        }

        private void ExecuteMove(Maze maze, Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    MoveUp(maze);
                    break;
                case Direction.Down:
                    MoveDown(maze);
                    break;
                case Direction.Left:
                    MoveLeft(maze);
                    break;
                case Direction.Right:
                    MoveRight(maze);
                    break;
            }
        }

        private enum Direction { None, Up, Down, Left, Right }

        private struct MoveOption
        {
            public Direction Direction { get; }
            public double Score { get; }

            public MoveOption(Direction direction, double score)
            {
                Direction = direction;
                Score = score;
            }
        }
    }
}
