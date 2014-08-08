namespace ComputerBuildingSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class HardDrive
    {
        private readonly bool isInRaid;

        private readonly int hardDrivesInRaidCount;

        private readonly IList<HardDrive> hardDrives;

        private readonly int capacity;

        private readonly IDictionary<int, string> data;

        internal HardDrive()
        {
        }

        internal HardDrive(int capacity, bool isInRaid, int hardDrivesInRaid)
            : this(capacity, isInRaid, hardDrivesInRaid, new List<HardDrive>())
        {
        }

        internal HardDrive(int capacity, bool isInRaid, int hardDrivesInRaid, IList<HardDrive> hardDrives)
        {
            this.isInRaid = isInRaid;
            this.hardDrivesInRaidCount = hardDrivesInRaid;
            this.capacity = capacity;

            this.data = new Dictionary<int, string>(capacity);
            this.hardDrives = hardDrives;
        }

        public int Capacity
        {
            get
            {
                if (this.isInRaid)
                {
                    if (!this.hardDrives.Any())
                    {
                        return 0;
                    }

                    return this.hardDrives.First().Capacity;
                }
                else
                {
                    return this.capacity;
                }
            }
        }

        public void SaveData(int address, string newData)
        {
            if (this.isInRaid)
            {
                foreach (var hardDrive in this.hardDrives)
                {
                    hardDrive.SaveData(address, newData);
                }
            }
            else
            {
                this.data[address] = newData;
            }
        }

        public string LoadData(int address)
        {
            if (this.isInRaid)
            {
                if (this.hardDrivesInRaidCount == 0)
                {
                    throw new OutOfMemoryException("No hard drive in the RAID array!");
                }

                return this.hardDrives.First().LoadData(address);
            }
            else
            {
                return this.data[address];
            }
        }
    }
}