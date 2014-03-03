namespace AcademyRPG
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Rock : StaticObject, IWorldObject, IResource
    {
        private const int InitialRockOwnerIndex = 0;

        public Rock(int hitPoints, Point position)
            : base(position, InitialRockOwnerIndex)
        {
            this.HitPoints = hitPoints;
        }

        public int Quantity
        {
            get
            {
                return this.HitPoints / 2;
            }
        }

        public ResourceType Type
        {
            get
            {
                return ResourceType.Stone;
            }
        }
    }
}
