using System.Drawing;
using Final_Assignment.Properties;

namespace Final_Assignment.Entities
{
    public class BlackDragon : MovingEntity
    {
        public BlackDragon(Vector2D positon, double scale = 1)
            : base(positon,
                new Vector2D(2, 2), //Heading. 
                300, //mass.
                0.3f, //max speed.
                100, //max force.
                100, //max turn rate.
                new Bitmap(Resources.BlackDragon, //Model
                    new Size((int) (Resources.BlackDragon.Width*scale), (int) (Resources.BlackDragon.Height*scale))),
                scale)
        {
            SteeringBehaviours.WallAvoidanceOn = true;
            SteeringBehaviours.FleeOn = true;
        }
    }
}