using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace AStarChessKing
{
    class AStar
    {
        public Grid grid;
        public AStar(Grid _grid)
        {
            grid = _grid;

        }
        public int Solve()
        {
            return FindPath(grid.start, grid.end)?.Count() ?? -1;
        }

        public Stack<Node> FindPath(Vector2 Start, Vector2 End)
        {
            bool isFinished = false;

            Node start = new Node(new Vector2(Start.X, Start.Y), grid.grid[(int)Start.X, (int)Start.Y].isWalkable);
            Node end = new Node(new Vector2(End.X, End.Y), true);

            Stack<Node> Path = new Stack<Node>();
            List<Node> OpenList = new List<Node>();
            List<Node> ClosedList = new List<Node>();
            List<Node> adjacencies;
            Node current = start;

            if (!current.isWalkable) return null; // if start isn't walkable

            OpenList.Add(start);
            start.isOpened = true;

            while (OpenList.Count != 0 && !isFinished)
            {
                current = OpenList[0]; // item with lowest F

                OpenList.Remove(current);
                current.isOpened = false;

                ClosedList.Add(current);
                current.isClosed = true;

                adjacencies = grid.GetAdjacentNodes(current);


                foreach (Node n in adjacencies)
                {
                    if (n.isWalkable && !n.isClosed && !n.isOpened)
                    {
                        n.parent = current;
                        n.distanceToTarget = Math.Max(Math.Abs(n.position.X - end.position.X), Math.Abs(n.position.Y - end.position.Y));
                        n.cost = n.weight + n.parent.cost;

                        OpenList.Add(n);
                        n.isOpened = true;
                        OpenList = OpenList.OrderBy(node => node.F).ToList<Node>();

                        if (n.distanceToTarget == 0)
                        {
                            isFinished = true;
                            break;
                        }
                    }
                }
            }

            // construct path, if end was not closed return null
            if (!isFinished) return null;

            // if all good, return path
            return ReturnPath(Path, current);
        }

        private static Stack<Node> ReturnPath(Stack<Node> Path, Node current)
        {
            Node temp = current;
            do
            {
                Path.Push(temp);
            } while ((temp = temp.parent) != null);
            return Path;
        }
    }
}
