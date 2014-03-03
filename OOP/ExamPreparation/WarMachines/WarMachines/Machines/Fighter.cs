using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarMachines.Interfaces;

namespace WarMachines.Machines
{
    public class Fighter : Machine, IFighter, IMachine
    {
        private bool stealthModeState;

        public Fighter(string name, double attackPoints, double defensePoints, bool initialStealthMode)
            : base(name, attackPoints, defensePoints)
        {
            this.StealthMode = initialStealthMode;
            this.HealthPoints = 200;
        }

        public bool StealthMode
        {
            get { return this.stealthModeState; }
            private set
            {
                this.stealthModeState = value;
            }
        }

        public void ToggleStealthMode()
        {
            if (this.StealthMode)
            {
                this.StealthMode = false;
            }
            else
            {
                this.StealthMode = true;
            }
        }

        public override string ToString()
        {
            StringBuilder fighterInfo = new StringBuilder();

            fighterInfo.AppendLine(base.ToString());

            if (this.StealthMode)
            {
                fighterInfo.AppendLine(" *Stealth: ON");
            }
            else
            {
                fighterInfo.AppendLine(" *Stealth: OFF");
            }

            return fighterInfo.ToString().Trim();
        }
    }
}
