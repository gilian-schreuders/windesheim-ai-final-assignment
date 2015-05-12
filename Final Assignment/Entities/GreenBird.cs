using System.Drawing;
using Final_Assignment.Properties;

namespace Final_Assignment.Entities
{
    public class GreenBird : MovingEntity
    {
        public GreenBird(Vector2D positon, double scale = 1)
            : base(positon,
                new Vector2D(1, 1), //Heading. 
                300, //mass.
                0.5f, //max speed.
                100, //max force.
                100, //max turn rate.
                new Bitmap(Resources.GreenBird, //Model
                    new Size((int) (Resources.GreenBird.Width*scale), (int) (Resources.GreenBird.Height*scale))),
                scale)
        {
        }
    }
}