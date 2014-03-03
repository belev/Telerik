namespace AcademyRPG
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Knight : Character, IControllable, IFighter, IWorldObject
    {
        private const int InitialAttackPoints = 100;
        private const int InitialDefensePoints = 100;
        private const int InitialHitPoints = 100;

        public Knight(string name, Point position, int owner)
            : base(name, position, owner)
        {
            this.HitPoints = InitialHitPoints;
        }

        public int AttackPoints
        {
            get { return InitialAttackPoints; }
        }

        public int DefensePoints
        {
            get { return InitialDefensePoints; }
        }

        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            for (int i = 0; i < availableTargets.Count; i++)
            {
                if (availableTargets[i].Owner != this.Owner && availableTargets[i].Owner != 0 && availableTargets[i] as IInvulnarable == null)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
