using System;
using System.Numerics;
using System.Collections.Generic;

namespace AStarChessKing
{
    class Program
    {
        public const int size = 8; // standard chess board size
        public static Grid mygrid;
        static void Main(string[] args)
        {
            LoadInput();
            var myAStar = new AStar(mygrid);
            Console.WriteLine(myAStar.Solve()); 
        }

        private static void LoadInput()
        {
            var grid = new Grid(size, size);

            grid.numOfWalls = int.Parse(Console.ReadLine());
            grid.walls = GetVectorList(grid, grid.numOfWalls);

            var pathPoints = GetVectorList(grid, 2);
            grid.start = pathPoints[0];
            grid.end = pathPoints[1];

            grid.CreateGrid();
            mygrid = grid;
        }

        private static List<Vector2> GetVectorList(Grid grid, int topBound)
        {
            var list = new List<Vector2>();
            for (int i = 0; i < topBound; i++)
            {
                string input = Console.ReadLine();
                string[] numbers = input.Split(' ');

                int xPos = int.Parse(numbers[0]) - 1;
                int yPos = int.Parse(numbers[1]) - 1;

                list.Add(new Vector2(xPos, yPos));
            }
            return list;
        }
    }
}
