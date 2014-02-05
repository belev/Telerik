using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointInSpace
{
    //03.Write a static class with a static method to calculate the distance between two points in the 3D space.

    public static class Distance
    {
        public static double CalculateDistance(Point first, Point second)
        {
            double distanceX = (first.X - second.X) * (first.X - second.X);
            double distaceY = (first.Y - second.Y) * (first.Y - second.Y);
            double distanceZ = (first.Z - second.Z) * (first.Z - second.Z);

            double distance = Math.Sqrt(distanceX + distaceY + distanceZ);

            return distance;
        }
    }
}
