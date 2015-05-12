using System;
using System.Drawing;

namespace Final_Assignment.Entities
{
    public abstract class MovingEntity : BaseGameEntity
    {
        /*=====================================================================================
         Constructors
         =====================================================================================*/

        protected MovingEntity(Vector2D positon, Vector2D heading, double mass, double maxSpeed,
            double maxForce,
            double maxTurnRate,
            Bitmap model,
            double scale = 1) : base(positon, model, scale)
        {
            Velocity = new Vector2D(0, 0);
            Heading = heading;
            Mass = mass;
            MaxSpeed = maxSpeed;
            MaxForce = maxForce;
            MaxTurnRate = maxTurnRate;
            SteeringBehaviours = new SteeringBehaviours(this);
        }

        /*=====================================================================================
         Properties
         =====================================================================================*/
        public Vector2D Velocity { get; protected set; }
        public Vector2D Heading { get; protected set; }
        public double Mass { get; protected set; }
        public double MaxSpeed { get; protected set; }
        public double MaxForce { get; protected set; }
        public double MaxTurnRate { get; protected set; }
        public SteeringBehaviours SteeringBehaviours { get; set; }
        /*=====================================================================================
         Methods
         =====================================================================================*/

        public virtual void Update(int timeElapsed)
        {
            var steeringForce = SteeringBehaviours.Calculate();
            var acceleration = steeringForce/Mass;
            Velocity += acceleration*timeElapsed; //time_elapsed
            Velocity.Truncate(MaxSpeed);
            Position += Velocity*timeElapsed; //time

            if (Velocity.Length() > 0.00000001)
            {
                Heading = Vector2D.Normalize(Velocity);
            }
        } 
    }
}