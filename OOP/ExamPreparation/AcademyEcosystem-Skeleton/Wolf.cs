namespace AcademyEcosystem
{
    using System;

    public class Wolf : Animal, IOrganism, ICarnivore
    {
        private const int InitialWolfSize = 4;

        public Wolf(string name, Point position)
            : base(name, position, InitialWolfSize)
        {
        }


        public int TryEatAnimal(Animal animal)
        {

            if (animal != null && (this.Size >= animal.Size || animal.State == AnimalState.Sleeping))
            {
                return animal.GetMeatFromKillQuantity();
            }

            return 0;
        }
    }
}
