namespace Infestation
{
    public class AggressionInhibitor : Supplement, ISupplement
    {
        private const int GeneralPowerEffect = 0;
        private const int GeneralHealthEffect = 0;
        private const int GeneralAggressionEffect = 3;

        public AggressionInhibitor()
            : base(AggressionInhibitor.GeneralPowerEffect, AggressionInhibitor.GeneralHealthEffect, AggressionInhibitor.GeneralAggressionEffect)
        {
        }
    }
}
