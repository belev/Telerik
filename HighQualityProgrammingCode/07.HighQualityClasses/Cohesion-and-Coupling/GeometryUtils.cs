namespace CohesionAndCoupling
{
    using System;

    public static class GeometryUtils
    {
        public static double CalcDistance2D(double firstPointX, double firstPointY, double secondPointX, double secondPointY)
        {
            double xSquared = (firstPointX - secondPointX) * (firstPointX - secondPointX);
            double ySquared = (firstPointY - secondPointY) * (firstPointY - secondPointY);

            double squaredDistance = xSquared + ySquared;

            double distance = Math.Sqrt(squaredDistance);
            return distance;
        }

        public static double CalcDistanceToCenter2D(double distanceToOx, double distanceToOy)
        {
            double distance = CalcDistance2D(0, 0, distanceToOx, distanceToOy);
            return distance;
        }

        public static double CalcDistance3D(double firstPointX, double firstPointY, double firstPointZ, double secondPointX, double secondPointY, double secondPointZ)
        {
            double xSquared = (firstPointX - secondPointX) * (firstPointX - secondPointX);
            double ySquared = (firstPointY - secondPointY) * (firstPointY - secondPointY);
            double zSquared = (firstPointZ - secondPointZ) * (firstPointZ - secondPointZ);

            double squaredDistance = xSquared + ySquared + zSquared;
            double distance = Math.Sqrt(squaredDistance);
            return distance;
        }

        public static double CalcDistanceToCenter3D(double distanceToOx, double distanceToOy, double distanceToOz)
        {
            double distance = CalcDistance3D(0, 0, 0, distanceToOx, distanceToOy, distanceToOz);
            return distance;
        }
    }
}
