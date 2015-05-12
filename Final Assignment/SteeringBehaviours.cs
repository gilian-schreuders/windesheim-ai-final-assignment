using System;
using System.Collections.Generic;

namespace Final_Assignment.Entities
{
    public class SteeringBehaviours
    {
        public SteeringBehaviours(MovingEntity entity)
        {
            Entity = entity;
            SeekOn = false;
            FleeOn = false;
            WanderOn = false;
            WallAvoidanceOn = false;
        }

        public MovingEntity Entity { get; private set; }
        public bool SeekOn { get; set; }
        public bool FleeOn { get; set; }
        public bool WanderOn { get; set; }
        public bool WallAvoidanceOn { get; set; }

        public Vector2D Calculate()
        {
            var steeringForce = new Vector2D();

            if (SeekOn) steeringForce += Seek(Game.World.MovingEntities[0].Position);
            if (FleeOn) steeringForce += Flee(Game.World.MovingEntities[0].Position);
            if (WanderOn) steeringForce += Wander();
            if (WallAvoidanceOn) steeringForce += WallAvoidance(Game.World.Walls);

            return steeringForce;
        }

        public Vector2D Seek(Vector2D target)
        {
            var desiredVelocity = Vector2D.Normalize(target - Entity.Position)*Entity.MaxSpeed;
            return desiredVelocity - Entity.Velocity;
        }

        public Vector2D Flee(Vector2D target)
        {
            var desiredVelocity = Vector2D.Normalize(Entity.Position - target)*Entity.MaxSpeed;
            return desiredVelocity - Entity.Velocity;
        }

        public Vector2D Wander()
        {
            const double radius = 20;
            const double wanderDistance = 2;
            const double jitter = 5;
            var random = new Random();
            var wanderTarget = new Vector2D(0, 0);
            Vector2D targetLocal;
            Vector2D targetWorld;

            wanderTarget += new Vector2D(random.Next(-1, 1)*jitter, random.Next(-1, 1)*jitter);
            wanderTarget.Normalize();
            wanderTarget *= radius;

            targetLocal = wanderTarget + new Vector2D(wanderDistance, 0);

            targetWorld = new Vector2D(0, 0); //TODO: fix this

            return targetWorld - Entity.Position;
        }

        public Vector2D WallAvoidance(List<Wall> walls)
        {
            //Variables_________________________________________________
            const double feelerLength = 300;

            Vector2D temporary;
            Vector2D point = null;
            Vector2D closestPoint = null;
            Vector2D overshoot = null;

            Wall closestWall = null;

            var steeringForce = new Vector2D(0, 0);
            var feelers = new Vector2D[3];
            var currentDistance = 0.0;
            var closestDistance = double.MaxValue;

            //Logic____________________________________________________

            #region Create feelers

            feelers[0] = Entity.Position + feelerLength*Entity.Heading;

            temporary = Entity.Heading;
            temporary.Rotate((Math.PI/2)*3.5);
            feelers[1] = Entity.Position + (feelerLength/2.0)*temporary;

            temporary = Entity.Heading;
            temporary.Rotate((Math.PI/2)*0.5);
            feelers[2] = Entity.Position + (feelerLength/2.0)*temporary;

            #endregion

            foreach (var feeler in feelers)
            {
                foreach (var wall in walls)
                {
                    if (LineIntersection2D(Entity.Position, feeler, wall.A, wall.B, ref currentDistance, ref point))
                    {
                        if (currentDistance < closestDistance)
                        {
                            closestDistance = currentDistance;
                            closestWall = wall;
                            closestPoint = point;
                        }
                    }
                } //Next wall

                if (closestWall != null)
                {
                    overshoot = feeler - closestPoint;
                    steeringForce = closestWall.GetNormal()*overshoot.Length();
                }
            } //Next feeler

            return steeringForce;
        }

        private bool LineIntersection2D(Vector2D a, Vector2D b, Vector2D c, Vector2D d, ref double distance,
            ref Vector2D point)
        {
            var rTop = (a.Y - c.Y)*(d.X - c.X) - (a.X - c.X)*(d.Y - c.Y);
            var rBot = (b.X - a.X)*(d.Y - c.Y) - (b.Y - a.Y)*(d.X - c.X);

            var sTop = (a.Y - c.Y)*(b.X - a.X) - (a.X - c.X)*(b.Y - a.Y);
            var sBot = (b.X - a.X)*(d.Y - c.Y) - (b.Y - a.Y)*(d.X - c.X);

            if ((rBot == 0) || (sBot == 0))
            {
                //lines are parallel
                return false;
            }

            var r = rTop/rBot;
            var s = sTop/sBot;

            if ((r > 0) && (r < 1) && (s > 0) && (s < 1))
            {
                distance = Vector2D.Disntance(a, b)*r;

                point = a + r*(b - a);

                return true;
            }

            distance = 0;

            return false;
        }

        public Vector2D ForwardComponent()
        {
            throw new NotImplementedException();
        }

        public Vector2D SideComponent()
        {
            throw new NotImplementedException();
        }

        public void SetPath()
        {
            throw new NotImplementedException();
        }

        public void SetTarget(Vector2D target)
        {
            throw new NotImplementedException();
        }

        public void SetTargetAgent1(Vector2D target)
        {
            throw new NotImplementedException();
        }

        public void SetTargetAgent2(Vector2D target)
        {
            throw new NotImplementedException();
        }
    }
}