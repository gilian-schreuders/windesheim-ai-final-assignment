using System.Drawing;
using Final_Assignment.Properties;

namespace Final_Assignment.Entities
{
    public class RedDragon : MovingEntity
    {
        public RedDragon(Vector2D positon, double scale = 1)
            : base(positon,
                new Vector2D(1, 1), //Heading. 
                300, //mass.
                0.5f, //max speed.
                100, //max force.
                100, //max turn rate.
                new Bitmap(Resources.RedDragon, //Model
                    new Size((int) (Resources.RedDragon.Width*scale), (int) (Resources.RedDragon.Height*scale))),
                scale)
        {
        }

        public override void Update(int timeElapsed)
        {
            Position.X += 1;
            Position.Y += 1;
        }
    }
}