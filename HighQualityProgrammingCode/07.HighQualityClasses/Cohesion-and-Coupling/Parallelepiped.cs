namespace CohesionAndCoupling
{
    using System;

    public class Parallelepiped
    {
        private double width;
        private double height;
        private double depth;

        public Parallelepiped(double width, double height, double depth)
        {
            this.Width = width;
            this.Height = height;
            this.Depth = depth;
        }

        public double Width
        {
            get
            {
                return this.width;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Parallelepiped width can not be zero or negative number.");
                }

                this.width = value;
            }
        }


        public double Height
        {
            get
            {
                return this.height;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Parallelepiped height can not be zero or negative number.");
                }

                this.height = value;
            }
        }

        public double Depth
        {
            get
            {
                return this.depth;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Parallelepiped depth can not be zero or negative number.");
                }

                this.depth = value;
            }
        }

        public double CalcVolume()
        {
            double volume = this.Width * this.Height * this.Depth;
            return volume;
        }


        public double CalcBodyDiagonal()
        {
            double distance = GeometryUtils.CalcDistanceToCenter3D(this.Width, this.Height, this.Depth);
            return distance;
        }

        public double CalcDiagonalXY()
        {
            double distance = GeometryUtils.CalcDistanceToCenter2D(this.Width, this.Height);
            return distance;
        }

        public double CalcDiagonalXZ()
        {
            double distance = GeometryUtils.CalcDistanceToCenter2D(this.Width, this.Depth);
            return distance;
        }

        public double CalcDiagonalYZ()
        {
            double distance = GeometryUtils.CalcDistanceToCenter2D(this.Height, this.Depth);
            return distance;
        }
    }
}
