namespace FurnitureManufacturer.Models
{
    using FurnitureManufacturer.Interfaces;

    using System;
    using System.Text;

    public abstract class Furniture : IFurniture
    {
        private const int FurnitureModelMinimumNumberOfSymbols = 3;

        private string model;
        private string material;
        private decimal price;
        private decimal height;

        public Furniture(string model, string materialType, decimal price, decimal height)
        {
            this.Model = model;
            this.Material = materialType;
            this.Price = price;
            this.Height = height;
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Furnityre model cannot be null or empty!");
                }

                if (value.Length < FurnitureModelMinimumNumberOfSymbols)
                {
                    throw new ArgumentOutOfRangeException("Furniture model must contain at least 3 symbols!");
                }

                this.model = value;
            }
        }

        public string Material
        {
            get
            {
                return this.material;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Material type cannot be null or empty!");
                }

                this.material = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value <= 0.00M)
                {
                    throw new ArgumentOutOfRangeException("Furniture price cannot be zero or negative!");
                }

                this.price = value;
            }
        }

        public decimal Height
        {
            get
            {
                return this.height;
            }
            protected set
            {
                if (value <= 0.00M)
                {
                    throw new ArgumentOutOfRangeException("Furniture height cannot be zero or negative!");
                }
                this.height = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append(string.Format("Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}", this.GetType().Name, this.Model, this.Material, this.Price, this.Height));

            return result.ToString();
        }
    }
}
