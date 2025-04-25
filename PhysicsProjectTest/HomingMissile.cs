using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsProjectTest
{
    class HomingMissile
    {

        public Vector3 Position { get; private set; }
        public Vector3 Velocity { get; private set; }
        public float Speed { get; private set; }
        public float TurnRate { get; private set; }

        public HomingMissile(Vector3 startPosition, float speed, float turnRate)
        {
            Position = startPosition;
            Speed = speed;
            TurnRate = turnRate;
            Velocity = new Vector3(0, 0, 0);
        }

        public Vector3 UpdatePosition(Vector3 targetPosition, double deltaTime)
        {
            Vector3 directionToTarget = new Vector3(
                targetPosition.X - Position.X,
                targetPosition.Y - Position.Y,
                targetPosition.Z - Position.Z
            );

            double distance = Math.Sqrt(
                directionToTarget.X * directionToTarget.X +
                directionToTarget.Y * directionToTarget.Y +
                directionToTarget.Z * directionToTarget.Z
            );

            if (distance > 0)
            {
                directionToTarget.X /= distance;
                directionToTarget.Y /= distance;
                directionToTarget.Z /= distance;
            }

            double currentSpeed = Math.Sqrt(
                Velocity.X * Velocity.X +
                Velocity.Y * Velocity.Y +
                Velocity.Z * Velocity.Z
            );

            Vector3 currentDirection = new Vector3(
                currentSpeed > 0 ? Velocity.X / currentSpeed : directionToTarget.X,
                currentSpeed > 0 ? Velocity.Y / currentSpeed : directionToTarget.Y,
                currentSpeed > 0 ? Velocity.Z / currentSpeed : directionToTarget.Z
            );

            double interpolationFactor = TurnRate * deltaTime;
            Vector3 newDirection = new Vector3(
                currentDirection.X + (directionToTarget.X - currentDirection.X) * interpolationFactor,
                currentDirection.Y + (directionToTarget.Y - currentDirection.Y) * interpolationFactor,
                currentDirection.Z + (directionToTarget.Z - currentDirection.Z) * interpolationFactor
            );

            double newDirLength = Math.Sqrt(
                newDirection.X * newDirection.X +
                newDirection.Y * newDirection.Y +
                newDirection.Z * newDirection.Z
            );

            if (newDirLength > 0)
            {
                newDirection.X /= newDirLength;
                newDirection.Y /= newDirLength;
                newDirection.Z /= newDirLength;
            }

            Velocity = new Vector3(
                newDirection.X * Speed,
                newDirection.Y * Speed,
                newDirection.Z * Speed
            );

            Position = new Vector3(
                Position.X + Velocity.X * deltaTime,
                Position.Y + Velocity.Y * deltaTime,
                Position.Z + Velocity.Z * deltaTime
            );

            return Position;
        }

        public double GetDistanceToTarget(Vector3 targetPosition)
        {
            double dx = targetPosition.X - Position.X;
            double dy = targetPosition.Y - Position.Y;
            double dz = targetPosition.Z - Position.Z;
            return Math.Sqrt(dx * dx + dy * dy + dz * dz);
        }
    }
}
