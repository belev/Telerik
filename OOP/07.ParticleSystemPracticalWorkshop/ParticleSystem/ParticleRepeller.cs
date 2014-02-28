namespace ParticleSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    // 05.Implement a ParticleRepeller class. A ParticleRepeller is a Particle, which pushes other particles away from it
    // (i.e. accelerates them in a direction, opposite of the direction in which the repeller is). 
    // The repeller has an effect only on particles within a certain radius (see Euclidean distance)

    public class ParticleRepeller : Particle, IRenderable, IAcceleratable
    {
        private readonly char[,] InitialParticleRepellerImage = new char[,] { { 'R' } };

        public ParticleRepeller(MatrixCoords position, MatrixCoords speed, int repellerPower, double radius)
            : base(position, speed)
        {
            this.RepellerPower = repellerPower;
            this.RepellerRadius = radius;
        }

        public int RepellerPower { get; private set; }
        public double RepellerRadius { get; set; }

        public override char[,] GetImage()
        {
            return InitialParticleRepellerImage;
        }
    }
}
