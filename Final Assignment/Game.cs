using System;
using System.Timers;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace Final_Assignment
{
    public partial class Game : Form
    {
        /*=====================================================================
         Variables
         =====================================================================*/
        public static readonly World World = new World();
        /*=====================================================================
         Constructors
         =====================================================================*/

        public Game()
        {
            InitializeComponent();

            ViewPort = new ViewPort(this);
            Done = true;

            //Set timer
            var timer = new Timer();
            timer.Elapsed += Run;
            timer.Interval = 16.68; //60 FPS
            timer.Enabled = true;
            Time = DateTime.Now;
        }

        /*=====================================================================
         Properties
         =====================================================================*/
        //Arrow Keys
        public bool UpKey { get; private set; }
        public bool DownKey { get; private set; }
        public bool LeftKey { get; private set; }
        public bool RightKey { get; private set; }
        //Other keys
        public bool F1Key { get; private set; }
        public bool F2Key { get; private set; }
        //Others
        public ViewPort ViewPort { get; private set; }
        public DateTime Time { get; private set; }
        public bool Done { get; private set; }
        /*=====================================================================
         Methods
         =====================================================================*/

        private void KeyLogic()
        {
//            Invoke((Action) (() =>
//            {
//                if (UpKey)
//                {
//                    ViewPort.Up();
//                }
//                if (DownKey)
//                {
//                    ViewPort.Down();
//                }
//                if (LeftKey)
//                {
//                    ViewPort.Left();
//                }
//                if (RightKey)
//                {
//                    ViewPort.Right();
//                }
//            }));
        }

        private void Logic(DateTime signalTime)
        {
            var timeElapsed = (signalTime - Time).Milliseconds;

            foreach (var baseGameEntity in World.MovingEntities)
            {
                baseGameEntity.Update(timeElapsed);
            }

            Time = signalTime;
        }

        private void Draw()
        {
            Canvas.Invalidate();
        }

        /*=====================================================================
         Events
         =====================================================================*/

        private void Run(object source, ElapsedEventArgs e)
        {
            if (!Done) return;
            Done = false;
            Logic(e.SignalTime);
            Draw();
            Done = true;
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            //Non painting:
            if (UpKey)
            {
                ViewPort.Up();
            }
            if (DownKey)
            {
                ViewPort.Down();
            }
            if (LeftKey)
            {
                ViewPort.Left();
            }
            if (RightKey)
            {
                ViewPort.Right();
            }

            //Draw front graph
            if (F1Key)
            {
                World.Graph.Draw(e.Graphics);
            }

            //Draw entities
            foreach (var movingEntity in World.MovingEntities)
            {
                movingEntity.Renderer(e.Graphics);
            }

            foreach (var staticEntity in World.StaticEntities)
            {
                staticEntity.Renderer(e.Graphics);
            }

            //Draw back graph
            if (F2Key)
            {
                World.Graph.Draw(e.Graphics);
            }
        }

        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }

            if (e.KeyCode == Keys.F1)
            {
                F1Key = true;
            }

            if (e.KeyCode == Keys.F2)
            {
                F2Key = true;
            }

            if (e.KeyCode == Keys.Left)
            {
                LeftKey = true;
            }

            if (e.KeyCode == Keys.Right)
            {
                RightKey = true;
            }

            if (e.KeyCode == Keys.Up)
            {
                UpKey = true;
            }

            if (e.KeyCode == Keys.Down)
            {
                DownKey = true;
            }
        }

        private void Game_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                F1Key = false;
            }

            if (e.KeyCode == Keys.F2)
            {
                F2Key = false;
            }

            if (e.KeyCode == Keys.Left)
            {
                LeftKey = false;
            }

            if (e.KeyCode == Keys.Right)
            {
                RightKey = false;
            }

            if (e.KeyCode == Keys.Up)
            {
                UpKey = false;
            }

            if (e.KeyCode == Keys.Down)
            {
                DownKey = false;
            }
        }
    }
}