using Final_Assignment.Entities;

namespace Final_Assignment
{
    public class Wall
    {
        public Wall(Vector2D a, Vector2D b)
        {
            A = a;
            B = b;
        }

        public Wall(int aX, int aY, int bX, int bY)
        {
            A = new Vector2D(aX, aY);
            B = new Vector2D(bX, bY);
        }

        public Vector2D A { get; set; }
        public Vector2D B { get; set; }

        public Vector2D GetNormal()
        {
            var temp = Vector2D.Normalize(B - A);
            return new Vector2D(-temp.Y, temp.X);
        }
    }
}