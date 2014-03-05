namespace Infestation
{
    public class PowerInhibitor: Supplement, ISupplement
    {
        private const int GeneralPowerEffect = 3;
        private const int GeneralHealthEffect = 0;
        private const int GeneralAggressionEffect = 0;

        public PowerInhibitor()
            : base(PowerInhibitor.GeneralPowerEffect, PowerInhibitor.GeneralHealthEffect, PowerInhibitor.GeneralAggressionEffect)
        {
        }
    }
}
