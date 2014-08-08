namespace ComputerBuildingSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class Computer : IMotherboard
    {
        public Computer(ICpu cpu, IRam ram, IEnumerable<HardDrive> hardDrives, VideoCardBase videoCard)
        {
            this.Cpu = cpu;
            this.Ram = ram;
            this.HardDrives = hardDrives;
            this.VideoCard = videoCard;
        }

        protected ICpu Cpu { get; private set; }

        protected IRam Ram { get; private set; }

        protected IEnumerable<HardDrive> HardDrives { get; private set; }

        protected VideoCardBase VideoCard { get; private set; }

        public int LoadRamValue()
        {
            return this.Ram.LoadValue();
        }

        public void SaveRamValue(int value)
        {
            this.Ram.SaveValue(value);
        }

        public void DrawOnVideoCard(string data)
        {
            this.VideoCard.DrawTextData(data);
        }
    }
}