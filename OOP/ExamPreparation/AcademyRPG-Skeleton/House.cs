namespace AcademyRPG
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class House : StaticObject, IWorldObject
    {
        private const int InitialHitPoints = 500;

        public House(Point position, int owner)
            : base(position, owner)
        {
            this.HitPoints = InitialHitPoints;
        }
    }
}
