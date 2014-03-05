namespace Infestation
{
    public class WeaponrySkill : Supplement
    {
        private const int GeneralPowerEffect = 0;
        private const int GeneralHealthEffect = 0;
        private const int GeneralAggressionEffect = 0;

        public WeaponrySkill()
            : base(WeaponrySkill.GeneralPowerEffect, WeaponrySkill.GeneralHealthEffect, WeaponrySkill.GeneralAggressionEffect)
        {
        }
    }
}
