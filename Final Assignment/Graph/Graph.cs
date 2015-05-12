using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Final_Assignment.Entities;

namespace Final_Assignment.Graph
{
    public class Graph
    {
        /*=================================================================
         Constructors
         =================================================================*/
        //Basic
        public Graph()
        {
            Map = new Dictionary<int, Node>();
        }

        //Fill graph
        public Graph(int width, int height, int dencity) : this()
        {
            InitializeNodes(width, height, dencity);
            InitializeEdges(width, height, dencity);
        }

        //Fill graph but not at a static position
        public Graph(int width, int height, int dencity, List<BaseGameEntity> staticEntities) : this()
        {
            InitializeNodes(width, height, dencity);
            ClearNodes(staticEntities);
            InitializeEdges(width, height, dencity);
        }

        /*=================================================================
         Properties
         =================================================================*/
        public Dictionary<int, Node> Map { get; private set; }
        /*=================================================================
         Private methods
         =================================================================*/

        //Clear nodes where obstacles are.
        private void ClearNodes(List<BaseGameEntity> staticEntities)
        {
            double nodeX;
            double nodeY;
            double entityX1;
            double entityX2;
            double entityY1;
            double entityY2;
            double entityWidth;
            double entityHeight;

            foreach (var staticEntity in staticEntities)
            {
                //Set entity size
                entityWidth = staticEntity.Model.Width;
                entityHeight = staticEntity.Model.Height;

                //Set X's
                entityX1 = staticEntity.Position.X;
                entityX2 = staticEntity.Position.X + entityWidth;

                //Set Y's
                entityY1 = staticEntity.Position.Y;
                entityY2 = staticEntity.Position.Y + entityHeight;

                foreach (var node in Map.Values.ToList())
                {
                    nodeX = node.Position.X;
                    nodeY = node.Position.Y;

                    if (nodeX >= entityX1 && nodeX <= entityX2 && //X
                        nodeY >= entityY1 && nodeY <= entityY2) //Y
                    {
                        Map.Remove(node.Id);
                    }
                }
            }
        }

        private void InitializeNodes(int width, int height, int dencity)
        {
            Node tempNode;
            var rowCount = height/dencity;
            var columnCount = width/dencity;

            for (var y = 0; y < rowCount; y++)
            {
                for (var x = 0; x < columnCount; x++)
                {
                    tempNode = new Node(x*dencity, y*dencity);
                    Map.Add(tempNode.Id, tempNode);
                }
            }
        }

        private void InitializeEdges(int width, int height, int dencity)
        {
            Node tempNode;
            int tempId;

            var rowCount = height/dencity;
            var columnCount = width/dencity;

            double nodeRow;
            double eastNodeRow;
            double westNodeRow;

            int northNodeRow;
            int southNodeRow;
            int southeastNodeRow;
            int southwestNodeRow;

            foreach (var node in Map.Values)
            {
                tempNode = node;
                tempId = node.Id;

                nodeRow = Math.Floor(tempId/(double) columnCount);
                northNodeRow = tempId - columnCount;
                eastNodeRow = Math.Floor((tempId + 1)/(double) columnCount);
                westNodeRow = Math.Floor((tempId - 1)/(double) columnCount);
                southNodeRow = tempId + columnCount;
                southeastNodeRow = tempId + columnCount + 1;
                southwestNodeRow = tempId + columnCount - 1;

                //Add North
                try
                {
                    tempNode.AddEdge(Map[northNodeRow]);
                }
                catch (Exception)
                {
                    // Do not add.
                }

                //Add East
                if (nodeRow == eastNodeRow)
                {
                    try
                    {
                        tempNode.AddEdge(Map[tempId + 1]);
                    }
                    catch (Exception)
                    {
                        // Do not add.
                    }
                }

                //Add Southeast
                //                try
                //                {
                //                    tempNode.AddEdge(Map[southeastNodeRow);
                //                }
                //                catch (Exception)
                //                {
                //                    // Do not add.
                //                }

                //Add South
                try
                {
                    tempNode.AddEdge(Map[southNodeRow]);
                }
                catch (Exception)
                {
                    // Do not add.
                }

                //Add Southwest
                //                try
                //                {
                //                    tempNode.AddEdge(Map[southwestNodeRow);
                //                }
                //                catch (Exception)
                //                {
                //                    // Do not add.
                //                }

                //Add West
                if (nodeRow == westNodeRow)
                {
                    try
                    {
                        tempNode.AddEdge(Map[tempId - 1]);
                    }
                    catch (Exception)
                    {
                        // Do not add.
                    }
                }
            }
        }

        private void ResetNodes()
        {
            foreach (var node in Map.Values)
            {
                node.Reset();
            }
        }

        /*=================================================================
         Public methods
         =================================================================*/

        public void Dijkstra(int id)
        {
            var queue = new Queue<Edge>();

            Node startNode;
            Node node1;
            Node node2;

            Edge edge1;

            int nodesSeen;

            double cost;

            try
            {
                startNode = Map[id];
            }
            catch
            {
                return; //No node/id found
            }

            ResetNodes();
            queue.Enqueue(new Edge(startNode, 0));

            nodesSeen = 0;
            while (queue.Count != 0 && nodesSeen < Map.Count)
            {
                edge1 = queue.Dequeue();
                node1 = edge1.Destination;

                if (node1.Scratch != 0)
                {
                    break;
                }

                node1.Scratch = 1;
                nodesSeen++;

                foreach (var edge in node1.Edges)
                {
                    node2 = edge.Destination;
                    cost = edge.Cost;

                    if (cost < 0)
                    {
                        throw new Exception("Graph ahs negative edges.");
                    }

                    if (node2.Distance > node1.Distance + cost)
                    {
                        node2.Distance = node1.Distance + cost;
                        node2.Previous = node1;
                        queue.Enqueue(new Edge(node2, node2.Distance));
                    }
                }
            }
        }

        public void Draw(Graphics graphics)
        {
            var dotPen = new Pen(Color.Orange, 3);
            var linePen = new Pen(Color.Orange, 1);
            Rectangle rect;
            int x;
            int y;
            int dX;
            int dY;

            foreach (var node in Map.Values)
            {
                x = (int) node.Position.X;
                y = (int) node.Position.Y;
                rect = new Rectangle(x, y, 3, 3);
                graphics.DrawEllipse(dotPen, rect);

                foreach (var edge in node.Edges)
                {
                    dX = (int) edge.Destination.Position.X;
                    dY = (int) edge.Destination.Position.Y;
                    graphics.DrawLine(linePen, x, y, dX, dY);
                }
            }
        }
    }
}