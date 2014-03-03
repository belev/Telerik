using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarMachines.Interfaces;

namespace WarMachines.Machines
{
    public abstract class Machine : IMachine
    {
        private string name;
        private IPilot pilot;
        private double healthPoints;
        private double attackPoints;
        private double defensePoints;
        private IList<string> targets;

        public Machine(string name, double attackPoints, double defensePoints)
        {
            this.Name = name;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.targets = new List<string>();
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (value == string.Empty || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException();
                    // Console.WriteLine("Name can not be null, empty or whitespace.");
                }
                else
                {
                    this.name = value;
                }
            }
        }

        public IPilot Pilot
        {
            get { return this.pilot; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException();
                    // Console.WriteLine("Pilot can not be null.");
                }
                else
                {
                    this.pilot = value;
                }
            }
        }

        public double HealthPoints
        {
            get { return this.healthPoints; }
            set
            {
                if (value < 0)
                {
                    this.healthPoints = 0;
                }
                else
                {
                    this.healthPoints = value;
                }
            }
        }

        public double AttackPoints
        {
            get { return this.attackPoints; }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                    // Console.WriteLine("Attack points can not be negative.");
                }
                else
                {
                    this.attackPoints = value;
                }
            }
        }

        public double DefensePoints
        {
            get { return this.defensePoints; }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                    // Console.WriteLine("Defense points can not be negative.");
                }
                else
                {
                    this.defensePoints = value;
                }
            }
        }

        public IList<string> Targets
        {
            get { return new List<string>(this.targets); }
            protected set
            {
                if (value == null)
                {
                    throw new ArgumentException();
                }

                this.targets = value;
            }
        }

        public void Attack(string target)
        {
            if (string.IsNullOrEmpty(target))
            {
                throw new ArgumentNullException("Target cannot be null or empty!");
            }

            this.Targets.Add(target);
        }

        public override string ToString()
        {
            StringBuilder machineInfo = new StringBuilder();

            string type = this.GetType().Name;
            machineInfo.AppendFormat("- {0}", this.Name);
            machineInfo.AppendLine();

            machineInfo.AppendFormat(" *Type: {0}", type);
            machineInfo.AppendLine();

            machineInfo.AppendFormat(" *Health: {0}", this.HealthPoints);
            machineInfo.AppendLine();

            machineInfo.AppendFormat(" *Attack: {0}", this.AttackPoints);
            machineInfo.AppendLine();

            machineInfo.AppendFormat(" *Defense: {0}", this.DefensePoints);
            machineInfo.AppendLine();

            if (this.Targets.Count == 0)
            {
                machineInfo.AppendFormat(" *Targets: None");
            }
            else
            {
                machineInfo.AppendFormat(" *Targets: {0}", string.Join(", ", this.Targets));
            }

            return machineInfo.ToString();
        }
    }
}
