using System;

namespace Final_Assignment.Entities
{
    public class Vector2D
    {
        /*=================================================
         Constructors
         =================================================*/

        public Vector2D(double x, double y)
        {
            X = x;
            Y = y;
        }

        public Vector2D()
        {
            X = 0;
            Y = 0;
        }

        /*=================================================
         Properties
         =================================================*/
        public double X { get; set; }
        public double Y { get; set; }
        /*=================================================
         Static Methods
         =================================================*/

        public static Vector2D Normalize(Vector2D vector)
        {
            var magnitude = Math.Sqrt(vector.X*vector.X + vector.Y*vector.Y);
            return new Vector2D(vector.X/magnitude, vector.Y/magnitude);
        }

        public static double Disntance(Vector2D a, Vector2D b)
        {
            var xSeparation = b.X - a.X;
            var ySeparation = b.Y - a.Y;
            return ySeparation*ySeparation + xSeparation*xSeparation;
        }

        /*=================================================
         Methods
         =================================================*/

        public Vector2D GetPerpendicular()
        {
            return new Vector2D(-Y, X);
        }

        public Vector2D Normalize()
        {
            var magnitude = Math.Sqrt(X*X + Y*Y);
            X /= magnitude;
            Y /= magnitude;

            return this;
        }

        public double Length()
        {
            return Math.Sqrt(X*X + Y*Y);
        }

        public void Rotate(double radians)
        {
            X = X*Math.Cos(radians) - Y*Math.Sin(radians);
            Y = X*Math.Sin(radians) + Y*Math.Cos(radians);
        }

        public Vector2D Truncate(double max)
        {
            if (!(Length() > max)) return this;

            Normalize();
            X *= max;
            Y *= max;

            return this;
        }

        /*=================================================
         Opperator overloads
         =================================================*/

        public static Vector2D operator /(Vector2D vector, double a)
        {
            return new Vector2D(vector.X/a, vector.Y/a);
        }

        public static Vector2D operator *(Vector2D vector, double a)
        {
            return new Vector2D(vector.X*a, vector.Y*a);
        }

        public static Vector2D operator *(double a, Vector2D vector)
        {
            return new Vector2D(vector.X*a, vector.Y*a);
        }

        public static Vector2D operator *(Vector2D vector, int a)
        {
            return new Vector2D(vector.X*a, vector.Y*a);
        }

        public static Vector2D operator +(Vector2D vector, Vector2D vector2)
        {
            return new Vector2D(vector.X + vector2.X, vector.Y + vector2.Y);
        }

        public static Vector2D operator +(Vector2D vector, double a)
        {
            return new Vector2D(vector.X + a, vector.Y + a);
        }

        public static Vector2D operator +(double a, Vector2D vector)
        {
            return new Vector2D(vector.X + a, vector.Y + a);
        }

        public static Vector2D operator -(Vector2D vector1, Vector2D vector2)
        {
            return new Vector2D(vector1.X - vector2.X, vector1.Y - vector2.Y);
        }
    }
}