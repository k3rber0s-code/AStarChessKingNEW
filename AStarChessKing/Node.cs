using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;


namespace AStarChessKing
{
    class Node
    {
        public Vector2 position;
        public bool isWalkable;
        public float distanceToTarget; // H
        public float cost; // G
        public float weight; // edge weight
        public Node parent;
        public bool isClosed;
        public bool isOpened;

        public float F
        {
            get
            {
                if (distanceToTarget != -1 && cost != -1)
                    return distanceToTarget + cost;
                else
                    return -1;
            }
        }

        public Node(Vector2 _position, bool _isWalkable=true)
        {
            parent = null;
            position = _position;
            isWalkable = _isWalkable;
            distanceToTarget = -1;
            cost = 1;
            weight = 1;
            isClosed = false;
            isOpened = false;
        }

    }
}
