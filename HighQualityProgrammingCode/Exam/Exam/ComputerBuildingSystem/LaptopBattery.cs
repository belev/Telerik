namespace ComputerBuildingSystem
{
    using ComputerBuildingSystem.Contracts;

    public class LaptopBattery : IChargeable
    {
        public const int InitialBatteryPercentage = 50;
        public const int MinimumBatteryPercentage = 0;
        public const int MaximumBatteryPercentage = 100;

        private int percentage;

        public LaptopBattery()
        {
            this.Percentage = InitialBatteryPercentage;
        }

        public int Percentage
        {
            get
            {
                return this.percentage;
            }

            set
            {
                if (value > MaximumBatteryPercentage)
                {
                    this.percentage = MaximumBatteryPercentage;
                }
                else if (value < MinimumBatteryPercentage)
                {
                    this.percentage = MinimumBatteryPercentage;
                }
                else
                {
                    this.percentage = value;
                }
            }
        }

        public void ChargeBattery(int percentage)
        {
            this.Percentage += percentage;
        }
    }
}