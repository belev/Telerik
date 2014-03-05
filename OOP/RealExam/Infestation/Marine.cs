namespace Infestation
{
    using System.Collections.Generic;
    using System.Linq;

    public class Marine : Human
    {
        public Marine(string name)
            :base(name)
        {
            WeaponrySkill weaponrySkill = new WeaponrySkill();

            base.AddSupplement(weaponrySkill);
        }

        protected override UnitInfo GetOptimalAttackableUnit(IEnumerable<UnitInfo> attackableUnits)
        {
            UnitInfo optimalAttackableUnit = new UnitInfo(null, UnitClassification.Unknown, int.MinValue, 0, 0);

            foreach (var unit in attackableUnits)
            {
                if (unit.Health > optimalAttackableUnit.Health)
                {
                    optimalAttackableUnit = unit;
                }
            }

            return optimalAttackableUnit;
        }
    }
}
