namespace AcademyEcosystem
{
    using System;

    public class Lion : Animal, IOrganism, ICarnivore
    {
        private const int InitialLionSize = 6;

        public Lion(string name, Point position)
            : base(name, position, InitialLionSize)
        {
        }

        public int TryEatAnimal(Animal animal)
        {
            if (animal != null)
            {
                if ((2 * this.Size) >= animal.Size)
                {
                    this.Size++;
                    return animal.GetMeatFromKillQuantity();
                }
            }

            return 0;
        }
    }
}
