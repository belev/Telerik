namespace ParticleSystem
{
    using System;
    using System.Collections.Generic;

    // 03.Create a ChickenParticle class. The ChickenParticle class moves like a ChaoticParticle, 
    // but randomly stops at different positions for several simulation ticks and, for each of those stops, 
    // creates (lays) a new ChickenParticle. You are not allowed to edit any existing class.


    public class ChickenParticle : ChaoticParticle, IRenderable, IAcceleratable
    {
        private readonly char[,] chickenParticleImage = new char[,] { { '8' } };
        private readonly MatrixCoords nullSpeed = new MatrixCoords(0, 0);

        private const uint InitialChanceToStopInPercents = 63;
        private MatrixCoords previousChickenParticleSpeed;

        private readonly uint ticksToStopForDurationCount;

        public ChickenParticle(MatrixCoords position, MatrixCoords speed, Random randGenerator)
            : base(position, speed, randGenerator)
        {
            this.ChanceToStopInPercentsCount = InitialChanceToStopInPercents;
            this.CurrentTickOfDuration = 0;
            ticksToStopForDurationCount = (uint)this.RandGenerator.Next(1, 6);
        }

        public ChickenParticle(MatrixCoords position, MatrixCoords speed, Random randGenerator, uint chanceToStopInPercentsCount)
            : this(position, speed, randGenerator)
        {
            this.ChanceToStopInPercentsCount = chanceToStopInPercentsCount;
        }

        private uint ChanceToStopInPercentsCount { get; set; }
        private bool HasStopped { get; set; }
        public int CurrentTickOfDuration { get; private set; }

        public override char[,] GetImage()
        {
            return this.chickenParticleImage;
        }

        public override IEnumerable<Particle> Update()
        {
            if (!HasStopped && this.RandGenerator.Next(0, 101) <= this.ChanceToStopInPercentsCount)
            {
                // save the previous chicken particle speed
                previousChickenParticleSpeed = this.Speed;

                // set the current speed to zero so that the chicken particle wont move
                this.Accelerate(this.oppositeSpeedDirection);

                this.HasStopped = true;
            }

            if (this.HasStopped)
            {
                this.CurrentTickOfDuration++;

                if (this.CurrentTickOfDuration == this.ticksToStopForDurationCount)
                {
                    this.HasStopped = false;
                    this.CurrentTickOfDuration = 0;

                    // set the speed back to the speed, which was before the chicken particle stops
                    this.Accelerate(this.previousChickenParticleSpeed);
                }

                // create new chicken particle
                var newProducedChickenParticle = new List<Particle>()
                    {
                        new ChickenParticle(this.Position, previousChickenParticleSpeed, this.RandGenerator)
                    };

                //get all previous produced particles

                var baseProducedParticles = base.Update();

                // and add them to the newly produced particle
                newProducedChickenParticle.AddRange(baseProducedParticles);

                return newProducedChickenParticle;
            }

            // if hasnt stop, we dont create new chicken particles so we simply call the base update method
            return base.Update();
        }
    }
}
