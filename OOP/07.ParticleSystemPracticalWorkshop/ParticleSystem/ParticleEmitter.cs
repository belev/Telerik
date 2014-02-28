using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParticleSystem
{
    public class ParticleEmitter : Particle
    {
        public Random RandGenerator { get; private set; }

        private uint maxEmittedPerTickCount;
        public int MinSpeedCoord { get; private set; }
        public int MaxSpeedCoord { get; private set; }

        private Func<ParticleEmitter, Particle> randomParticleGeneratorMethod;

        public ParticleEmitter(MatrixCoords position, MatrixCoords speed, Random randGenerator, uint maxEmittedPerTickCount, uint maxAbsSpeedCoord, Func<ParticleEmitter, Particle> randomParticleGeneratorMethod)
            : base(position, speed)
        {
            this.RandGenerator = randGenerator;
            this.maxEmittedPerTickCount = maxEmittedPerTickCount;
            this.MinSpeedCoord = -(int) maxAbsSpeedCoord;
            this.MaxSpeedCoord = (int) maxAbsSpeedCoord;
            this.randomParticleGeneratorMethod = randomParticleGeneratorMethod;
        }

        public override IEnumerable<Particle> Update()
        {
            var baseProduced = base.Update();

            var produced = new List<Particle>();

            int emittedCount = this.RandGenerator.Next((int) this.maxEmittedPerTickCount + 1);

            for (int i = 0; i < emittedCount; i++)
            {
                Particle p = GetRandomParticle();
                produced.Add(p);
            }

            produced.AddRange(baseProduced);
            return produced;
        }

        private Particle GetRandomParticle()
        {
           

            Particle result = this.randomParticleGeneratorMethod(this);

            return result;
        }
    }
}
