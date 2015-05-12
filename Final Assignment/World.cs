using System;
using System.Collections.Generic;
using Final_Assignment.Entities;
using Final_Assignment.Properties;

namespace Final_Assignment
{
    public class World
    {
        /*=================================================================================
         Variables
         =================================================================================*/
        public readonly int WorldHeight = Resources.Background.Height;
        public readonly int WorldWidth = Resources.Background.Width;
        /*=================================================================================
         Constructors
         =================================================================================*/

        public World()
        {
            //Create game walls
            Walls = new List<Wall>
            {
                //Top
                new Wall(0, 0, WorldWidth, 0),
                //Bottom
                new Wall(0, WorldHeight, WorldWidth, WorldHeight),
                //Left
                new Wall(0, 0, 0, WorldHeight),
                //Right
                new Wall(WorldWidth, 0, WorldWidth, WorldHeight)
            };

            //Create all Moving characters.
            MovingEntities = new List<MovingEntity>
            {
                new RedDragon(new Vector2D(0, 0)),
                new BlueDragon(new Vector2D(0, 100)),
                new BlackDragon(new Vector2D(100, 200)),
                new GreenBird(new Vector2D(0, 300)),
                new PurpleBird(new Vector2D(200, 200)),
                new Character(new Vector2D(200, 400))
            };


            //Create static objects.
            StaticEntities = new List<BaseGameEntity>
            {
                new Cloud(new Vector2D(300, 300)),
                new Cloud(new Vector2D(400, 400)),
                new Cloud(new Vector2D(500, 500)),
                new Cloud(new Vector2D(600, 600))
            };

            Graph = new Graph.Graph(WorldWidth, WorldHeight, 50, StaticEntities);
            Graph.Dijkstra(200);
            var test = Graph.GetPath(0);
        }

        /*=================================================================================
         Properties
         =================================================================================*/
        public List<MovingEntity> MovingEntities { get; private set; }
        public List<BaseGameEntity> StaticEntities { get; private set; }
        public List<Wall> Walls { get; private set; }
        public Graph.Graph Graph { get; set; }
    }
}