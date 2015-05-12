using System.Drawing;
using Final_Assignment.Properties;

namespace Final_Assignment.Entities
{
    public class PurpleBird : MovingEntity
    {
        public PurpleBird(Vector2D positon, double scale = 1)
            : base(positon,
                new Vector2D(1, 1), //Heading. 
                2000, //mass.
                0.01, //max speed.
                100, //max force.
                100, //max turn rate.
                new Bitmap(Resources.PurpleBird, //Model
                    new Size((int) (Resources.PurpleBird.Width*scale), (int) (Resources.PurpleBird.Height*scale))),
                scale)
        {
            SteeringBehaviours.FleeOn = true;
        }
    }
}