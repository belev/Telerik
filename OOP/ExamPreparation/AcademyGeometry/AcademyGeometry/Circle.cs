namespace AcademyGeometry
{
    using System;
    public class Circle : Figure, IAreaMeasurable, ITransformable, IFlat
    {
        public Circle(double radius, Vector3D center)
            : base(center)
        {
            this.Radius = radius;
        }

        public double Radius { get; private set; }

        public Vector3D Center
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

        public override double GetPrimaryMeasure()
        {
            double primaryMeasure = this.GetArea();

            return primaryMeasure;
        }

        public override Vector3D GetCenter()
        {
            return this.Center;
        }

        public double GetArea()
        {
            double area = Math.PI * this.Radius * this.Radius;

            return area;
        }

        public Vector3D GetNormal()
        {
            // use the logic from triangle
            // get 3 points on the circle and use the formula from the Triangle class
            Vector3D firstPointOnCircle = new Vector3D(this.Center.X + this.Radius, this.Center.Y, this.Center.Z);
            Vector3D secondPointOnCircle = new Vector3D(this.Center.X - this.Radius, this.Center.Y, this.Center.Z);
            Vector3D thirdPointOnCircle = new Vector3D(this.Center.X, this.Center.Y - this.Radius, this.Center.Z);

            Vector3D normal = Vector3D.CrossProduct(secondPointOnCircle - firstPointOnCircle, thirdPointOnCircle - firstPointOnCircle);
            normal.Normalize();
            return normal;
        }
    }
}
