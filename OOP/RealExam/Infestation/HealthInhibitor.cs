namespace Infestation
{
    public class HealthInhibitor : Supplement, ISupplement
    {
        private const int GeneralPowerEffect = 0;
        private const int GeneralHealthEffect = 3;
        private const int GeneralAggressionEffect = 0;

        public HealthInhibitor()
            : base(HealthInhibitor.GeneralPowerEffect, HealthInhibitor.GeneralHealthEffect, HealthInhibitor.GeneralAggressionEffect)
        {
        }
    }
}
