using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSystem
{
    public class AdvancedParticleOperator : ParticleUpdater
    {
        private List<ParticleAttractor> attractors = new List<ParticleAttractor>(); // for current tick
        private List<Particle> particles = new List<Particle>(); // for current tick

        public override IEnumerable<Particle> OperateOn(Particle p)
        {
            //find attractors
            var attractorCandidate = p as ParticleAttractor;

            if (attractorCandidate == null)
            {
               this.particles.Add(p);
            }
            else
            {
                this.attractors.Add(attractorCandidate);
            }

            return base.OperateOn(p);
        }

        public override void TickEnded()
        {
            foreach (var attractor in this.attractors)
            {
                foreach (var particle in this.particles)
                {
                    // look in the previous group video the code
                }
            }

            this.attractors.Clear();
            this.particles.Clear();
            base.TickEnded();
        }
    }
}
