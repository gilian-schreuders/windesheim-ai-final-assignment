using System.Drawing;
using Final_Assignment.Properties;

namespace Final_Assignment.Entities
{
    public class Character : MovingEntity
    {
        public Character(Vector2D positon, double scale = 1)
            : base(positon,
                new Vector2D(1, 1), //Heading. 
                1000, //mass.
                0.2f, //max speed.
                100, //max force.
                100, //max turn rate.
                new Bitmap(Resources.Character, //Model
                    new Size((int) (Resources.Character.Width*scale), (int) (Resources.Character.Height*scale))),
                scale) //Scale
        {
            SteeringBehaviours.SeekOn = true;
        }
    }
}