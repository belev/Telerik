namespace ParticleSystem
{
    using System;
    using System.Collections.Generic;

    // 05.Implement a ParticleRepeller class. A ParticleRepeller is a Particle, which pushes other particles away from it
    // (i.e. accelerates them in a direction, opposite of the direction in which the repeller is). 
    // The repeller has an effect only on particles within a certain radius (see Euclidean distance)

    public class ExtendedAdvancedParticleOperator : ParticleUpdater
    {
        private List<ParticleRepeller> repellers = new List<ParticleRepeller>(); // for current tick
        private List<Particle> particles = new List<Particle>(); // for current tick

        public override IEnumerable<Particle> OperateOn(Particle p)
        {
            //find attractors
            var repellerCandidate = p as ParticleRepeller;

            if (repellerCandidate == null)
            {
                this.particles.Add(p);
            }
            else
            {
                this.repellers.Add(repellerCandidate);
            }

            return base.OperateOn(p);
        }

        public override void TickEnded()
        {
            foreach (var repeller in this.repellers)
            {
                foreach (var particle in this.particles)
                {
                    double distanceFromRepellerToParticle = CalculateEuclideanDistance(repeller.Position, particle.Position);

                    if (repeller.RepellerRadius >= distanceFromRepellerToParticle)
                    {
                        var currParticleToRepellerVector = repeller.Position - particle.Position;

                        int pToAttrRow = currParticleToRepellerVector.Row;
                        pToAttrRow = DecreaseVectorCoordToPower(repeller, pToAttrRow);

                        int pToAttrCol = currParticleToRepellerVector.Col;
                        pToAttrCol = DecreaseVectorCoordToPower(repeller, pToAttrCol);

                        var currAcceleration = new MatrixCoords(-pToAttrRow, -pToAttrCol);

                        particle.Accelerate(currAcceleration);
                    }
                }
            }

            this.repellers.Clear();
            this.particles.Clear();

            base.TickEnded();
        }

        private static int DecreaseVectorCoordToPower(ParticleRepeller repeller, int pToAttrCoord)
        {
            if (Math.Abs(pToAttrCoord) > repeller.RepellerPower)
            {
                pToAttrCoord = (pToAttrCoord / (int) Math.Abs(pToAttrCoord)) * repeller.RepellerPower;
            }
            return pToAttrCoord;
        }

        private static double CalculateEuclideanDistance(MatrixCoords a, MatrixCoords b)
        {
            var distance = Math.Sqrt((a.Row - b.Row) * (a.Row - b.Row) + (a.Col - b.Col) * (a.Col - b.Col));

            return distance;
        }
    }
}
