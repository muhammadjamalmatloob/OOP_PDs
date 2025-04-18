using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MyPacMan
{
    public class Maze
    {
        private char[,] grid;
        public int Height { get; private set; }
        public int Width { get; private set; }

        public Maze(string filePath)
        {
            LoadFromFile(filePath);
        }

        private void LoadFromFile(string filePath)
        {
            
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                Height = lines.Length;
                Width = lines[0].Length;
                grid = new char[Height, Width];

                for (int x = 0; x < Height; x++)
                {
                    for (int y = 0; y < Width; y++)
                    {
                        grid[x, y] = lines[x][y];
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to load maze from {filePath}: {ex.Message}");
            }
        }

        public char GetCell(int x, int y)
        {
            if (x < 0 || x >= Height || y < 0 || y >= Width)
                return '#'; 
            return grid[x, y];
        }

        public bool IsWalkable(int x, int y)
        {
            char cell = GetCell(x, y);
            return cell == ' ' || cell == '.' || cell == 'P' || cell == 'G';
        }

        public bool HasPellet(int x, int y)
        {
            return GetCell(x, y) == '.';
        }

        public void ClearPellet(int x, int y)
        {
            if (x >= 0 && x < Height && y >= 0 && y < Width)
            {
                grid[x, y] = ' ';
            }
        }

        public void Draw()
        {
            Console.Clear();
            for (int x = 0; x < Height; x++)
            {
                for (int y = 0; y < Width; y++)
                {
                    Console.Write(grid[x, y]);
                }
                Console.WriteLine();
            }
        }

        public void UpdateCell(int x, int y, char value)
        {
            if (x >= 0 && x < Height && y >= 0 && y < Width)
            {
                grid[x, y] = value;
            }
        }

        public int CountRemainingPellets()
        {
            int count = 0;
            for (int x = 0; x < Height; x++)
            {
                for (int y = 0; y < Width; y++)
                {
                    if (grid[x, y] == '.')
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }
}
