using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarMachines.Interfaces;

namespace WarMachines.Machines
{
    public class Pilot : IPilot
    {
        private string name;
        private IList<IMachine> machinesEngaged;

        public Pilot(string name)
        {
            this.Name = name;
            this.MachinesEngaged = new List<IMachine>();
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (value == string.Empty || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException();
                    // Console.WriteLine("Name can not be null, empty or whitespace.");
                }
                else
                {
                    this.name = value;
                }

            }
        }

        public IList<IMachine> MachinesEngaged 
        {
            get { return this.machinesEngaged; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }

                this.machinesEngaged = value;
            }
        }

        public void AddMachine(Interfaces.IMachine machine)
        {
            if (machine == null)
            {
                throw new ArgumentNullException("Machine cannot be with null value!");
            }

            this.MachinesEngaged.Add(machine);
        }

        public string Report()
        {
            StringBuilder report = new StringBuilder();

            int engagedMachinesCount = this.machinesEngaged.Count();

            if (engagedMachinesCount == 0)
            {
                report.AppendFormat("{0} - no machines", this.Name);

                return report.ToString();
            }

            else if (engagedMachinesCount == 1)
            {
                report.AppendFormat("{0} - 1 machine", this.Name);
                report.AppendLine();
            }

            else
            {
                report.AppendFormat("{0} - {1} machines", this.Name, engagedMachinesCount);
                report.AppendLine();
            }

            var sortedMachines = this.MachinesEngaged.OrderBy(m => m.HealthPoints).ThenBy(m => m.Name);
            foreach (var machine in sortedMachines)
            {
                report.AppendLine(machine.ToString());
            }

            return report.ToString().Trim();
        }
    }
}
