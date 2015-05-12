using System.Drawing;
using Final_Assignment.Properties;

namespace Final_Assignment.Entities
{
    public class BlueDragon : MovingEntity
    {
        public BlueDragon(Vector2D positon, float scale = 1)
            : base(positon,
                new Vector2D(1, 1), //Heading. 
                300, //mass.
                0.5f, //max speed.
                100, //max force.
                100, //max turn rate.
                new Bitmap(Resources.BlueDragon, //Model
                    new Size((int)(Resources.BlueDragon.Width * scale), (int)(Resources.BlueDragon.Height * scale))),
                scale)
        {
            SteeringBehaviours.WanderOn = true;
        }

    }
}