namespace Infestation
{
    public class Weapon : Supplement, ISupplement
    {
        private const int GeneralPowerEffect = 10;
        private const int GeneralHealthEffect = 0;
        private const int GeneralAggressionEffect = 3;

        //initial weapon effects are equal to zero
        private const int InitialWeaponPowerEffect = 0;
        private const int InitialWeaponHealthEffect = 0;
        private const int InitialWeaponAggressionEffect = 0;

        public Weapon()
            : base(InitialWeaponPowerEffect, InitialWeaponHealthEffect, InitialWeaponAggressionEffect)
        {
        }

        // if unit have WeaponrySkill supplement, than set weapon effects to their general effects
        public override void ReactTo(ISupplement otherSupplement)
        {
            if (otherSupplement is WeaponrySkill)
            {
                this.PowerEffect = Weapon.GeneralPowerEffect;
                this.HealthEffect = Weapon.GeneralHealthEffect;
                this.AggressionEffect = Weapon.GeneralAggressionEffect;
            }
        }
    }
}
