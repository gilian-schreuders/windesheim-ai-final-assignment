using System.Collections.Generic;
using Final_Assignment.Entities;

namespace Final_Assignment.Graph
{
    public class Node
    {
        private static int _autoIncremental;

        public Node(int x, int y)
        {
            Reset();

            Id = _autoIncremental;
            _autoIncremental++;

            Position = new Vector2D(x, y);

            Edges = new List<Edge>();
        }

        public int Id { get; private set; }
        public List<Edge> Edges { get; private set; }
        public double Distance { get; set; }
        public Node Previous { get; set; }
        public int Scratch { get; set; }
        public Vector2D Position { get; set; }

        public void Reset()
        {
            Distance = double.MaxValue;
            Previous = null;
//            Position = null;
            Scratch = 0;
        }

        public void AddEdge(Node destination)
        {
            Edges.Add(new Edge(destination, 1));
        }
    }
}