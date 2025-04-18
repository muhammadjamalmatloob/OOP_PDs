using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EZInput;
using MyPacMan.DL;


namespace MyPacMan.UI
{ 
        public class GameController
        {
            private Maze maze;
            private PacMan pacman;
            private List<Ghost> ghosts;
            private bool isRunning;
            private int ghostUpdateCounter;

            public GameController()
            {
                InitializeGame();
            }

            private void InitializeGame()
            {
                maze = new Maze("maze.txt");
                pacman = new PacMan(9, 31);
                ghosts = new List<Ghost>
            {
                new HorizontalGhost(15, 39),
                new VerticalGhost(20, 57),
                new RandomGhost(19, 25),
                new SmartGhost(21, 30)
            };

                ScoreManager.Reset();
                isRunning = true;
                ghostUpdateCounter = 0;
            }

            public void RunGame()
            {
                maze.Draw();
                pacman.Draw();
                ghosts.ForEach(g => g.Draw());

                while (isRunning)
                {
                    HandleInput();
                    UpdateGame();
                    Thread.Sleep(90);
                }

                ShowGameOver();
            }

            private void HandleInput()
            {
                if (Keyboard.IsKeyPressed(Key.UpArrow))
                {
                    pacman.MoveUp(maze);
                }
                else if (Keyboard.IsKeyPressed(Key.DownArrow))
                {
                    pacman.MoveDown(maze);
                }
                else if (Keyboard.IsKeyPressed(Key.LeftArrow))
                {
                    pacman.MoveLeft(maze);
                }
                else if (Keyboard.IsKeyPressed(Key.RightArrow))
                {
                    pacman.MoveRight(maze);
                }
                else if (Keyboard.IsKeyPressed(Key.Escape))
                {
                    isRunning = false;
                }
            }

            private void UpdateGame()
            {
                ghostUpdateCounter++;

                
                foreach (var ghost in ghosts)
                {
                    if (ghost is HorizontalGhost && ghostUpdateCounter % 5 == 0)
                    {
                        ghost.Move(maze);
                    }
                    else if (ghost is VerticalGhost && ghostUpdateCounter % 2 == 0)
                    {
                        ghost.Move(maze);
                    }
                    else if (ghost is RandomGhost || ghost is SmartGhost)
                    {
                        ghost.Move(maze);
                    }
                }

                CheckCollisions();
                CheckPellets();
                ScoreManager.DisplayScore();

                if (maze.CountRemainingPellets() == 0)
                {
                    isRunning = false;
                }
            }

            private void CheckCollisions()
            {
                foreach (var ghost in ghosts)
                {
                    if (ghost.X == pacman.X && ghost.Y == pacman.Y)
                    {
                        isRunning = false;
                        return;
                    }
                }
            }

            private void CheckPellets()
            {
                if (maze.HasPellet(pacman.X, pacman.Y))
                {
                    maze.ClearPellet(pacman.X, pacman.Y);
                    ScoreManager.IncreaseScore();
                }
            }

            private void ShowGameOver()
            {
                Console.Clear();
                Console.SetCursorPosition(Console.WindowWidth / 2 - 5, Console.WindowHeight / 2);
                Console.Write("GAME OVER");
                Console.SetCursorPosition(Console.WindowWidth / 2 - 8, Console.WindowHeight / 2 + 1);
                Console.Write($"Final Score: {ScoreManager.Score}");
                Console.SetCursorPosition(Console.WindowWidth / 2 - 12, Console.WindowHeight / 2 + 3);
                Console.Write("Press any key to exit...");
                Console.ReadKey();
            }

            public void RestartGame()
            {
                InitializeGame();
                RunGame();
            }
        }
    }

