namespace PhysicsProjectTest
{
    public class ArcingProjectile
    {
        public static double MaxHeight(double initialVelocity, double verticalAngle)
        {
            double thetaRad = verticalAngle * Math.PI / 180.0;
            double v0y = initialVelocity * Math.Sin(thetaRad);
            return (v0y * v0y) / (2 * 9.81);
        }

        public static double TimeOfFlight(double initialVelocity, double verticalAngle)
        {
            double thetaRad = verticalAngle * Math.PI / 180.0;
            double v0y = initialVelocity * Math.Sin(thetaRad);
            return (2 * v0y) / 9.81;
        }
    }
}
