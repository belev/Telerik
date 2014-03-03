namespace AcademyEcosystem
{
    using System;

    public class Zombie : Animal
    {
        private const int InitialZombieHealth = 0;
        private const int InitialMeatFromKillQuantity = 10;

        public Zombie(string name, Point position)
            : base(name, position, InitialZombieHealth)
        {
        }

        public override int GetMeatFromKillQuantity()
        {
            return InitialMeatFromKillQuantity;
        }
    }
}
