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
    }
}
