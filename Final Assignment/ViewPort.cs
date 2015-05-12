using System.Windows.Threading;

namespace Final_Assignment
{
    public class ViewPort
    {
        public ViewPort(Game game)
        {
            Game = game;
            Canvas = game.Canvas;
            Width = Game.ClientSize.Width;
            Height = Game.ClientSize.Height;
        }

        public Game Game { get; private set; }
        public Canvas Canvas { get; set; }
        public int Width { get; private set; }
        public int Height { get; private set; }

        public void Up()
        {
            Dispatcher.CurrentDispatcher.Invoke(() =>
            {
                if (Canvas.Top >= 0)
                {
                    return;
                }

                Canvas.Top += 10;
            });
        }

        public void Down()
        {
            if (Canvas.Top + Height*0.55 <= 0)
            {
                return;
            }

            Canvas.Top -= 10;
        }

        public void Left()
        {
            if (Canvas.Left >= 0)
            {
                return;
            }

            Canvas.Left += 10;
        }

        public void Right()
        {
            if (Canvas.Left + Width*0.5 <= 0)
            {
                return;
            }

            Canvas.Left -= 10;
        }
    }
}