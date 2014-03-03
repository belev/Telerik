namespace AcademyEcosystem
{
    public class Grass : Plant, IOrganism
    {
        private const int InitialGrassSize = 2;

        public Grass(Point position)
            : base(position, InitialGrassSize)
        {
        }

        public override void Update(int time)
        {
            if (this.IsAlive)
            {
                this.Size += time;
            }

            base.Update(time);
        }
    }
}
