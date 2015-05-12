using System.Drawing;
using Final_Assignment.Properties;

namespace Final_Assignment.Entities
{
    public class Cloud : BaseGameEntity
    {
        public Cloud(Vector2D positon, double scale = 1)
            : base(
                positon,
                new Bitmap(Resources.cloud,
                    new Size((int) (Resources.cloud.Width*scale), (int) (Resources.cloud.Height*scale))), scale)
        {
        }
    }
}