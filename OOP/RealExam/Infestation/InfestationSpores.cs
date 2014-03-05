namespace Infestation
{
    using System;

    public class InfestationSpores : Supplement, ISupplement
    {
        private const int GeneralPowerEffect = -1;
        private const int GeneralHealthEffect = 0;
        private const int GeneralAggressionEffect = 20;

        public InfestationSpores()
            : base(InfestationSpores.GeneralPowerEffect, InfestationSpores.GeneralHealthEffect, InfestationSpores.GeneralAggressionEffect)
        {
        }

        public override void ReactTo(ISupplement otherSupplement)
        {
            if (otherSupplement is InfestationSpores)
            {
                this.PowerEffect = 0;
                this.HealthEffect = 0;
                this.AggressionEffect = 0;
            }
        }
    }
}
