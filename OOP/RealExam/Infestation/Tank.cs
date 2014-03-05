namespace Infestation
{
    public class Tank : Unit
    {
        private const int InitialTankPower = 25;
        private const int InitialTankHealth = 20;
        private const int InitialTankAggression = 25;

        private const UnitClassification GeneralTankType = UnitClassification.Mechanical;

        public Tank(string name)
            : base(name, Tank.GeneralTankType, Tank.InitialTankHealth, Tank.InitialTankPower, Tank.InitialTankAggression)
        {
        }
    }
}
