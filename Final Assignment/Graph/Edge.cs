namespace Final_Assignment.Graph
{
    public class Edge
    {
        public Edge(Node destination, double cost)
        {
            Destination = destination;
            Cost = cost;
        }

        public Node Destination { get; set; }
        public double Cost { get; set; }
    }
}