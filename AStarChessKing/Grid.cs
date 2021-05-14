using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AStarChessKing
{
    class Grid
    {
        public Vector2 gridWorldSize;
        public Node[,] grid;
        public List<Vector2> walls;
        public int numOfWalls;
        public Vector2 start;
        public Vector2 end;


        public Grid(int _xSize, int _ySize)
        {
            gridWorldSize.X = _xSize;
            gridWorldSize.Y = _ySize;
        }

        public void CreateGrid()
        {
            grid = new Node[(int)gridWorldSize.X, (int)gridWorldSize.Y];

            for (int i = 0; i < gridWorldSize.X; i++) // initialize each node in grid
            {
                for (int j = 0; j < gridWorldSize.Y; j++)
                {
                    grid[i, j] = new Node(new Vector2(i, j));
                }
            }

            for (int i = 0; i < numOfWalls; i++) // recognize the walls
            {
                grid[(int)walls[i].X, (int)walls[i].Y].isWalkable = false;
            }
        }
        public List<Node> GetAdjacentNodes(Node n)
        {
            List<Node> temp = new List<Node>();

            int row = (int)n.position.X;
            int col = (int)n.position.Y;

            for (int i = -1; i <=1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    bool isInXRange = 0 < row &&  row <= gridWorldSize.X;
                    bool isInYRange = 0 < col &&  col <= gridWorldSize.Y;
                    bool isSame = i == 0 && j == 0;

                    if (isInXRange && isInYRange && !isSame)
                    {
                        temp.Add(grid[row + i, col + j]);
                    }

                }
            }
            return temp;
            /*
            if (row + 1 < gridWorldSize.X) // BOTTOM
            {
                temp.Add(grid[row + 1, col]);
            }
            if (row - 1 >= 0) // TOP
            {
                temp.Add(grid[row - 1, col]);
            }
            if (col - 1 >= 0) // LEFT
            {
                temp.Add(grid[row, col - 1]);
            }
            if (col + 1 < gridWorldSize.Y) // RIGHT
            {
                temp.Add(grid[row, col + 1]);
            }
            if (col + 1 < gridWorldSize.Y && row + 1 < gridWorldSize.X) // BOTTOM-RIGHT
            {
                temp.Add(grid[row + 1, col + 1]);
            }
            if (col + 1 < gridWorldSize.Y && row - 1 >= 0) // TOP-RIGHT
            {
                temp.Add(grid[row - 1, col + 1]);
            }
            if (col - 1 >= 0 && row + 1 < gridWorldSize.X) // BOTTOM-LEFT
            {
                temp.Add(grid[row + 1, col - 1]);
            }
            if (col - 1 >= 0 && row - 1 >= 0) // TOP-LEFT
            {
                temp.Add(grid[row - 1, col - 1]);
            }
            */
        }
    }
}
