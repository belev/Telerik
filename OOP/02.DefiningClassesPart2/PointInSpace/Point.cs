using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointInSpace
{
    //01.Create a structure Point3D to hold a 3D-coordinate {X, Y, Z} in the Euclidian 3D space. Implement the ToString() to enable printing a 3D point.

    public struct Point
    {
        public static Point PointO
        {
            get { return pointO; }
        }

        //02.Add a private static read-only field to hold the start of the coordinate system – the point O{0, 0, 0}. Add a static property to return the point O.

        private static readonly Point pointO = new Point(0.0, 0.0, 0.0);

        public Point(double x, double y, double z)
            : this()
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public override string ToString()
        {
            StringBuilder pointOutput = new StringBuilder();

            pointOutput.AppendLine(string.Format("{0} {1} {2}", this.X, this.Y, this.Z));

            return pointOutput.ToString();
        }
    }
}
