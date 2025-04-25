using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsProjectTest
{
    class HomingMissileTest
    {

        [Test]
        public void TestMissileMovesTowardTarget()
        {
            Vector3 startPosition = new Vector3(0, 0, 0);
            Vector3 targetPosition = new Vector3(100, 0, 0);
            float missileSpeed = 10.0f;
            float turnRate = 1.0f;

            HomingMissile missile = new HomingMissile(startPosition, missileSpeed, turnRate);

            double initialDistance = missile.GetDistanceToTarget(targetPosition);
            missile.UpdatePosition(targetPosition, 1.0);
            double newDistance = missile.GetDistanceToTarget(targetPosition);

            Assert.That(newDistance, Is.LessThan(initialDistance));
        }

        [Test]
        public void TestMissileSpeed()
        {
            Vector3 startPosition = new Vector3(0, 0, 0);
            float missileSpeed = 10.0f;
            float turnRate = 1.0f;
            HomingMissile missile = new HomingMissile(startPosition, missileSpeed, turnRate);

            Vector3 targetPosition = new Vector3(100, 0, 0); 
            missile.UpdatePosition(targetPosition, 1.0);

            double actualSpeed = Math.Sqrt(
                missile.Velocity.X * missile.Velocity.X +
                missile.Velocity.Y * missile.Velocity.Y +
                missile.Velocity.Z * missile.Velocity.Z
            );

            Assert.That(actualSpeed, Is.EqualTo(missileSpeed).Within(0.001));
        }

        [Test]
        public void TestMissileTurning()
        {
            Vector3 startPosition = new Vector3(0, 0, 0);
            float missileSpeed = 10.0f;
            float turnRate = 0.5f;
            HomingMissile missile = new HomingMissile(startPosition, missileSpeed, turnRate);

            missile.UpdatePosition(new Vector3(100, 0, 0), 1.0); 
            Vector3 firstVelocity = missile.Velocity;
            missile.UpdatePosition(new Vector3(0, 100, 0), 1.0); 

            Assert.That(missile.Velocity.Y, Is.GreaterThan(0));
            Assert.That(missile.Velocity.X, Is.GreaterThan(0)); 
        }

        [Test,
            TestCase(0.0, 0.0, 0.0, 10.0, 0.0, 0.0, 1.0, 10.0, 0.0, 0.0), 
            // the above is a straight line
            TestCase(0.0, 0.0, 0.0, 10.0, 10.0, 0.0, 1.0, 7.07, 7.07, 0.0),
            // the above is 45 degrees
            TestCase(0.0, 0.0, 0.0, 0.0, 10.0, 0.0, 1.0, 0.0, 10.0, 0.0)  
            // the above is vertical
        ]
        public void TestMissileTrajectory(
            double startX, double startY, double startZ,
            double targetX, double targetY, double targetZ,
            double time,
            double expectedVelX, double expectedVelY, double expectedVelZ)
        {
            Vector3 startPosition = new Vector3(startX, startY, startZ);
            Vector3 targetPosition = new Vector3(targetX, targetY, targetZ);
            float missileSpeed = 10.0f;
            float turnRate = 1.0f;
            HomingMissile missile = new HomingMissile(startPosition, missileSpeed, turnRate);

            missile.UpdatePosition(targetPosition, time);

            Assert.That(missile.Velocity.X, Is.EqualTo(expectedVelX).Within(0.01));
            Assert.That(missile.Velocity.Y, Is.EqualTo(expectedVelY).Within(0.01));
            Assert.That(missile.Velocity.Z, Is.EqualTo(expectedVelZ).Within(0.01));
        }

    }
}
