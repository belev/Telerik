namespace Infestation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Queen : Unit
    {
        private const int InitialPower = 1;
        private const int InitialHealth = 30;
        private const int InitialAggression = 1;

        public Queen(string name)
            : base(name, UnitClassification.Psionic, Queen.InitialHealth, Queen.InitialPower, Queen.InitialAggression)
        {
        }

        public override Interaction DecideInteraction(IEnumerable<UnitInfo> units)
        {
            IEnumerable<UnitInfo> attackableUnits = units.Where((unit) => this.CanAttackUnit(unit));

            UnitInfo optimalAttackableUnit = GetOptimalAttackableUnit(attackableUnits);

            if (optimalAttackableUnit.Id != null)
            {
                return new Interaction(new UnitInfo(this), optimalAttackableUnit, InteractionType.Attack);
            }

            return Interaction.PassiveInteraction;
        }

        protected override UnitInfo GetOptimalAttackableUnit(IEnumerable<UnitInfo> attackableUnits)
        {
            UnitInfo optimalAttackableUnit = new UnitInfo(null, UnitClassification.Unknown, int.MaxValue, 0, 0);

            foreach (var unit in attackableUnits)
            {
                if (unit.Health < optimalAttackableUnit.Health)
                {
                    optimalAttackableUnit = unit;
                }
            }

            return optimalAttackableUnit;
        }

        protected override bool CanAttackUnit(UnitInfo unit)
        {
            bool attackUnit = false;

            if (this.Id != unit.Id)
            {
                if (InfestationRequirements.RequiredClassificationToInfest(this.UnitClassification) == InfestationRequirements.RequiredClassificationToInfest(unit.UnitClassification))
                {
                    attackUnit = true;
                }
            }

            return attackUnit;
        }
    }
}
