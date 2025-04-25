using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsProjectTest
{

    public class ArcingProjectileTest
    {

        [Test,
            TestCase(
                20.0,                        // initial velocity (m/s)
                45.0,                       // vertical angle (degrees)
                30.0,                      // horizontal angle (degrees)
                0.0,                      // time (s)
                0.0, 0.0, 0.0,           // start position
                0.0, 0.0, 0.0           // expected position at t=0
            ),
            TestCase(
                20.0,                      // initial velocity (m/s)
                45.0,                     // vertical angle (degrees)
                30.0,                    // horizontal angle (degrees)
                0.5,                    // time (s)
                0.0, 0.0, 0.0,         // start position
                6.123, 5.845, 3.535   // expected position at t=0.5
            ),
            TestCase(
                20.0,                      // initial velocity (m/s)
                45.0,                     // vertical angle (degrees)
                30.0,                    // horizontal angle (degrees)
                1.0,                    // time (s)
                0.0, 0.0, 0.0,         // start position
                12.247, 9.237, 7.071  // expected position at t=1.0
            )
        ]
        public void TestProjectileMotion3D(
                double initialVelocity,
                double verticalAngle,
                double horizontalAngle,
                double time,
                double startX, double startY, double startZ,
                double expectedX, double expectedY, double expectedZ)
            {

            Vector3 startPosition = new Vector3(startX, startY, startZ);
            Vector3 expectedPosition = new Vector3(expectedX, expectedY, expectedZ);

            double thetaRad = verticalAngle * Math.PI / 180.0;
            double phiRad = horizontalAngle * Math.PI / 180.0;

            double v0x = initialVelocity * Math.Cos(thetaRad) * Math.Cos(phiRad);
            double v0y = initialVelocity * Math.Sin(thetaRad);
            double v0z = initialVelocity * Math.Cos(thetaRad) * Math.Sin(phiRad);

            double x = startPosition.X + v0x * time;
            double y = startPosition.Y + (v0y * time) - (0.5 * 9.81 * time * time);
            double z = startPosition.Z + v0z * time;

            Console.WriteLine($"time: {time}");
            Console.WriteLine($"initial velocities:");
            Console.WriteLine($"v0x: {v0x}");
            Console.WriteLine($"v0y: {v0y}");
            Console.WriteLine($"v0z: {v0z}");
            Console.WriteLine($"expected position: ({expectedX}, {expectedY}, {expectedZ})");
            Console.WriteLine($"calculated position: ({x}, {y}, {z})");

            Vector3 result = ArcingProjectile.CalculateProjectilePosition(initialVelocity, verticalAngle, horizontalAngle, time, startPosition);

            Console.WriteLine($"final result: ({result.X}, {result.Y}, {result.Z})");

            Assert.That(result.X, Is.EqualTo(expectedX).Within(0.001));
            Assert.That(result.Y, Is.EqualTo(expectedY).Within(0.001));
            Assert.That(result.Z, Is.EqualTo(expectedZ).Within(0.001));
        }


        /*

[Test]
public void TestMaxHeightCalculation()
{
    double initialVelocity = 20.0;
    double verticalAngle = 45.0;

    double maxHeight = ArcingProjectile.MaxHeight(initialVelocity, verticalAngle);

    Assert.That(maxHeight, Is.EqualTo(10.2).Within(0.01));
    // in this test case, it should equal to
    // 10.2
    // but we apply a 0.00 difference
}

[Test]
public void TestTimeOfFlight()
{
    double initialVelocity = 20.0;
    double verticalAngle = 45.0;

    double timeOfFlight = ArcingProjectile.TimeOfFlight(initialVelocity, verticalAngle);

    Assert.That(timeOfFlight, Is.EqualTo(2.89).Within(0.01));
    // in this test case, it should equal to
    // 2.89
    // but we apply a 0.00 difference
}

*/

        // the above is for stuff i was going to add later but given my timeline
        // i simply dont have enough time to add different arcing projectile calculations right now




    }
}
    

