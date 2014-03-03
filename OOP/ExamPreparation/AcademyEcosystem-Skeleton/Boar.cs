namespace AcademyEcosystem
{
    using System;

    public class Boar : Animal, IOrganism, ICarnivore, IHerbivore
    {
        private const int InitialBoarSize = 4;
        private const int InitialBoarBiteSize = 2;

        public Boar(string name, Point position)
            : base(name, position, InitialBoarSize)
        {
        }

        public int TryEatAnimal(Animal animal)
        {
            if (animal != null)
            {
                if (this.Size >= animal.Size)
                {
                    return animal.GetMeatFromKillQuantity();
                }
            }

            return 0;
        }

        public int EatPlant(Plant plant)
        {
            if (plant != null)
            {
                this.Size++;
                return plant.GetEatenQuantity(InitialBoarBiteSize);
            }

            return 0;
        }
    }
}
