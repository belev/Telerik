namespace FurnitureManufacturer.Models
{
    using FurnitureManufacturer.Interfaces;

    using System;
    using System.Text;

    public class Chair : Furniture, IChair, IFurniture
    {
        private int numberOfLegs;

        public Chair(string model, string materialType, decimal price, decimal height, int numberOfLegs)
            : base(model, materialType, price, height)
        {
            this.NumberOfLegs = numberOfLegs;
        }

        public int NumberOfLegs
        {
            get
            {
                return this.numberOfLegs;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Chair number of legs cannot be less than zero!");
                }

                this.numberOfLegs = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            string baseToStringResult = base.ToString();

            result.Append(string.Format("{0}, Legs: {1}", baseToStringResult, this.NumberOfLegs));

            return result.ToString();
        }
    }
}
