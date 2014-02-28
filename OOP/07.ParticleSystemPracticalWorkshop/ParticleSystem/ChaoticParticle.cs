namespace ParticleSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    // 01.Create a ChaoticParticle class, which is a Particle, randomly changing its movement (Speed). You are not allowed to edit any existing class.

    public class ChaoticParticle : Particle, IRenderable, IAcceleratable
    {
        protected const int MaxSpeedChangeRange = 4;
        private readonly char[,] chaoticParticleImage = new char[,] { { '~' } };
        protected readonly MatrixCoords oppositeSpeedDirection;

        public ChaoticParticle(MatrixCoords position, MatrixCoords speed, Random randGenerator)
            : base(position, speed)
        {
            this.RandGenerator = randGenerator;
            this.oppositeSpeedDirection = new MatrixCoords(-this.Speed.Row, -this.Speed.Col);
        }

        protected Random RandGenerator { get; private set; }

        // override the GetImage method, because chaotic particle will have different image
        public override char[,] GetImage()
        {
            return this.chaoticParticleImage;
        }

        public override IEnumerable<Particle> Update()
        {
            // set speed to zero
            // use accelerate method because speed setter is private
            this.Accelerate(this.oppositeSpeedDirection);

            // generate new speed
            MatrixCoords speed = this.GenerateRandomSpeed();

            // set the speed to the newly generated speed
            this.Accelerate(speed);

            return base.Update();
        }

        private MatrixCoords GenerateRandomSpeed()
        {
            int randSpeedXCoord = this.RandGenerator.Next(-MaxSpeedChangeRange, MaxSpeedChangeRange + 1);
            int randSpeedYCoord = this.RandGenerator.Next(-MaxSpeedChangeRange, MaxSpeedChangeRange + 1);

            MatrixCoords randomSpeed = new MatrixCoords(randSpeedXCoord, randSpeedYCoord);

            return randomSpeed;
        }
    }
}
