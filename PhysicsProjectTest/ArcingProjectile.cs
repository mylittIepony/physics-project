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


        public static Vector3 CalculateProjectilePosition(double initialVelocity, double verticalAngle, double horizontalAngle, double time, Vector3 startPosition)
        {
            const double GRAVITY = 9.81;

            double thetaRad = verticalAngle * Math.PI / 180.0;
            double phiRad = horizontalAngle * Math.PI / 180.0;

            double v0x = initialVelocity * Math.Cos(thetaRad) * Math.Cos(phiRad);
            double v0y = initialVelocity * Math.Sin(thetaRad);
            double v0z = initialVelocity * Math.Cos(thetaRad) * Math.Sin(phiRad);

            double x = startPosition.X + v0x * time;
            double y = startPosition.Y + (v0y * time) - (0.5 * GRAVITY * time * time);
            double z = startPosition.Z + v0z * time;

            return new Vector3(x, y, z);
        }
    }

}