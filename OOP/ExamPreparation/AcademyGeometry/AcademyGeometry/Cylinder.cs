namespace AcademyGeometry
{
    using System;

    public class Cylinder : Figure, IVolumeMeasurable, IAreaMeasurable, ITransformable
    {
        private double height;
        public Cylinder(double radius, Vector3D bottomCenter, Vector3D topCenter)
            : base(bottomCenter, topCenter)
        {
            this.Radius = radius;
            this.height = this.CalculateCylinderHeight();
        }

        public double Radius { get; private set; }

        public Vector3D BottomCenter
        {
            get
            {
                return new Vector3D(this.vertices[0].X, this.vertices[0].Y, this.vertices[0].Z);
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Center of a circle cannot have null value.");
                }

                this.vertices[0] = value;
            }
        }

        public Vector3D TopCenter
        {
            get
            {
                return new Vector3D(this.vertices[1].X, this.vertices[1].Y, this.vertices[1].Z);
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Center of a circle cannot have null value.");
                }

                this.vertices[1] = value;
            }
        }

        public double GetVolume()
        {
            var cylinderVolume = Math.PI * this.Radius * this.Radius * this.height;

            return cylinderVolume;
        }

        public double GetArea()
        {
            var cylinderArea = 2 * Math.PI * this.Radius * (this.Radius + this.height);

            return cylinderArea;
        }

        public override double GetPrimaryMeasure()
        {
            var cylinderPrimaryMeasure = this.GetVolume();

            return cylinderPrimaryMeasure;
        }

        private double CalculateCylinderHeight()
        {
            double distanceX = (this.BottomCenter.X - this.TopCenter.X) * (this.BottomCenter.X - this.TopCenter.X);
            double distaceY = (this.BottomCenter.Y - this.TopCenter.Y) * (this.BottomCenter.Y - this.TopCenter.Y);
            double distanceZ = (this.BottomCenter.Z - this.TopCenter.Z) * (this.BottomCenter.Z - this.TopCenter.Z);

            double height = Math.Sqrt(distanceX + distaceY + distanceZ);

            return height;
        }
    }
}
