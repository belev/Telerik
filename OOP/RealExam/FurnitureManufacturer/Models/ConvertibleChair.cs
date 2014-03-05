namespace FurnitureManufacturer.Models
{
    using FurnitureManufacturer.Interfaces;

    using System;
    using System.Linq;
    using System.Text;

    public class ConvertibleChair : Chair, IFurniture, IChair, IConvertibleChair
    {
        private const bool InitialConvertibleChairState = false;
        private readonly decimal initialConvertibleChairHeight;

        public ConvertibleChair(string model, string materialType, decimal price, decimal height, int numberOfLegs)
            : base(model, materialType, price, height, numberOfLegs)
        {
            this.IsConverted = InitialConvertibleChairState;

            initialConvertibleChairHeight = height;
        }

        public bool IsConverted { get; private set; }

        public void Convert()
        {
            if (this.IsConverted)
            {
                this.Height = this.initialConvertibleChairHeight;
            }
            else
            {
                this.Height = 0.10M;
            }

            this.IsConverted = !this.IsConverted;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            string baseToStringResult = base.ToString();
            string stateAsString = this.IsConverted ? "Converted" : "Normal";

            result.Append(string.Format("{0}, State: {1}", baseToStringResult, stateAsString));

            return result.ToString();
        }
    }
}
