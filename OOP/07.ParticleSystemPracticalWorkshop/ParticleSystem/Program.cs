using System;
using System.Linq;

namespace ParticleSystem
{
    class Program
    {
        const int Rows = 30;
        const int Cols = 30;
        static readonly Random randGenerator = new Random();

        static void Main()
        {
            var renderer = new ConsoleRenderer(Rows, Cols);

            var particleOperator = new ParticleUpdater();

            var engine = new Engine(renderer, particleOperator, null, 300);

            GenerateInitialData(engine);

            engine.Run();
        }

        static void GenerateInitialData(Engine engine)
        {
            var emitterPosition = new MatrixCoords(29, 0);
            var emitterSpeed = new MatrixCoords(0, 0);

            var emitter = new ParticleEmitter(emitterPosition, emitterSpeed, randGenerator, 5, 2, GenerateRandomParticle);

            engine.AddParticle(emitter);

            //check attractor
            var attractorPosition = new MatrixCoords(10, 10);

            var attractor = new ParticleAttractor(attractorPosition, new MatrixCoords(0, 0), 1);

            engine.AddParticle(attractor);

            // 02.Test the ChaoticParticle through the ParticleSystemMain class
            // Create chaotic particle and add it to the engine
            var chaoticParticle = new ChaoticParticle(new MatrixCoords(15, 15), new MatrixCoords(1, 1), randGenerator);
            engine.AddParticle(chaoticParticle);

            // 04.Test the ChickenParticle class through the ParcticleSystemMain class.
            var chickenParticle = new ChickenParticle(new MatrixCoords(10, 10), new MatrixCoords(-1, 2), randGenerator, 20);
            engine.AddParticle(chickenParticle);

            // 06.Test the ParticleRepeller class through the ParticleSystemMain class
            // create repeller with large radius and power to see the result
            // because in one moment there are too many new chicken particles created
            var particleRepeller = new ParticleRepeller(new MatrixCoords(20, 20), new MatrixCoords(0, 0), 10, 20.0);
            engine.AddParticle(particleRepeller);
        }

        static Particle GenerateRandomParticle(ParticleEmitter emitterParam)
        {
            MatrixCoords particlePosition = emitterParam.Position;

            int particleRowSpeed = emitterParam.RandGenerator.Next(emitterParam.MinSpeedCoord, emitterParam.MaxSpeedCoord + 1);
            int particleColSpeed = emitterParam.RandGenerator.Next(emitterParam.MinSpeedCoord, emitterParam.MaxSpeedCoord + 1);

            var particleSpeed = new MatrixCoords(particleRowSpeed, particleColSpeed);

            Particle particleGenerated = null;
            int particleTypeIndex = emitterParam.RandGenerator.Next(0, 2);

            switch (particleTypeIndex)
            {
                case 0:
                    particleGenerated = new Particle(particlePosition, particleSpeed);
                    break;
                case 1:
                    particleGenerated = new DyingParticle(particlePosition, particleSpeed, (uint) emitterParam.RandGenerator.Next(8));
                    break;
                default:
                    throw new Exception("No such particle for this particle type index!");
            }

            return particleGenerated;
        }
    }
}
