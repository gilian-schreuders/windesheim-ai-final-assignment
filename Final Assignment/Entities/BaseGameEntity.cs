using System.Drawing;

namespace Final_Assignment.Entities
{
    public abstract class BaseGameEntity
    {
        /*==========================================================================
         Variables
         ==========================================================================*/
        private static int _incrementalId;
        /*==========================================================================
         Constructors
         ==========================================================================*/

        protected BaseGameEntity(Vector2D positon, Bitmap model, double scale = 1)
        {
            Id = _incrementalId;
            Scale = scale;
            Position = positon;
            Model = model;
            _incrementalId++;
        }

        /*==========================================================================
         Properties
         ==========================================================================*/
        public int Id { get; private set; }
        public double Scale { get; set; }
        public Vector2D Position { get; set; }
        public Bitmap Model { get; set; }
        /*==========================================================================
         Methods
         ==========================================================================*/

        public void Renderer(Graphics graphics)
        {
            graphics.DrawImage(Model, new Point((int) Position.X, (int) Position.Y));
        }
    }
}