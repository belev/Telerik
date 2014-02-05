using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ShapesProject
{
    public abstract class Shape
    {
        private double width;
        private double height;

        protected Shape(double height, double width)
        {
            this.height = height;
            this.width = width;
        }

        public double Width
        {
            get { return this.width; }
            set
            {
                if (value <= 0)
                {
                    throw new IndexOutOfRangeException("Width can not be negative or zero!");
                }

                this.width = value;
            }
        }

        public double Height
        {
            get { return this.height; }
            set
            {
                if (value <= 0)
                {
                    throw new IndexOutOfRangeException("Height can not be negative or zero!");
                }

                this.height = value;
            }
        }

        public abstract double CalculateSurface();
    }
}
