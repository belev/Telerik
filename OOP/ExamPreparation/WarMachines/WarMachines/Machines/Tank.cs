using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarMachines.Interfaces;

namespace WarMachines.Machines
{
    public class Tank : Machine, ITank, IMachine
    {
        private bool defenseModeState;

        public Tank(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints, defensePoints)
        {
            this.DefenseMode = true;

            this.AttackPoints -= 40;
            this.DefensePoints += 30;
            this.HealthPoints = 100;
        }

        public bool DefenseMode
        {
            get { return this.defenseModeState; }
            private set { this.defenseModeState = value; }
        }

        public void ToggleDefenseMode()
        {
            if (this.DefenseMode)
            {
                this.DefenseMode = false;

                this.AttackPoints += 40;
                this.DefensePoints -= 30;
            }
            else
            {
                this.DefenseMode = true;

                this.AttackPoints -= 40;
                this.DefensePoints += 30;
            }
        }

        public override string ToString()
        {
            StringBuilder tankInfo = new StringBuilder();

            tankInfo.Append(base.ToString());
            tankInfo.AppendLine();

            if (this.DefenseMode)
            {
                tankInfo.AppendLine(" *Defense: ON");
            }
            else
            {
                tankInfo.AppendLine(" *Defense: OFF");
            }

            return tankInfo.ToString().Trim();
        }
    }
}
