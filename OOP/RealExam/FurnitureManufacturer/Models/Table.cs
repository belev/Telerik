namespace FurnitureManufacturer.Models
{
    using FurnitureManufacturer.Interfaces;

    using System;
    using System.Text;

    public class Table : Furniture, ITable, IFurniture
    {
        private decimal lenght;
        private decimal width;

        public Table(string model, string materialType, decimal price, decimal height, decimal length, decimal width)
            : base(model, materialType, price, height)
        {
            this.Length = length;
            this.Width = width;
        }

        public decimal Length
        {
            get
            {
                return this.lenght;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Table length cannot be equal or less than zero!");
                }

                this.lenght = value;
            }
        }

        public decimal Width
        {
            get
            {
                return this.width;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Table width cannot be equal or less than zero!");
                }

                this.width = value;
            }

        }

        public decimal Area
        {
            get 
            {
                decimal tableArea = this.Length * this.Width;

                return tableArea;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            string baseToStringResult = base.ToString();

            result.Append(string.Format("{0}, Length: {1}, Width: {2}, Area: {3}", baseToStringResult, this.Length, this.Width, this.Area));

            return result.ToString();
        }
    }
}
