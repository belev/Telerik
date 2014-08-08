namespace ComputerBuildingSystem.Factories
{
    using System;

    public class ManufacturerFactory
    {
        public const string HpManufacturerName = "HP";
        public const string DellManufacturerName = "Dell";
        public const string LenovoManufacturerName = "Lenovo";

        public ComputersFactory CreateManufacturer(string manufacturerName)
        {
            if (manufacturerName == HpManufacturerName)
            {
                return new HpManufacturer();
            }
            else if (manufacturerName == DellManufacturerName)
            {
                return new DellManufacturer();
            }
            else if (manufacturerName == LenovoManufacturerName)
            {
                return new LenovoManufacturer();
            }
            else
            {
                throw new ArgumentException("Invalid manufacturer!");
            }
        }
    }
}
