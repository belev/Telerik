namespace ComputerBuildingSystem
{
    using System;
    using System.Collections.Generic;
    
    using ComputerBuildingSystem.Contracts;

    public class Laptop : Computer, IChargeable
    {
        public const string BatteryStatusMessageFormat = "Battery status: {0}%";

        private readonly LaptopBattery battery;

        public Laptop(ICpu cpu, IRam ram, IEnumerable<HardDrive> hardDrives, VideoCardBase videoCard, LaptopBattery battery)
            : base(cpu, ram, hardDrives, videoCard)
        {
            this.battery = battery;
        }

        public void ChargeBattery(int percentage)
        {
            this.battery.ChargeBattery(percentage);

            var batteryStatus = string.Format(Laptop.BatteryStatusMessageFormat, this.battery.Percentage);

            this.VideoCard.DrawTextData(batteryStatus);
        }
    }
}
