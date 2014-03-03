namespace AcademyRPG
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Ninja : Character, IControllable, IFighter, IGatherer, IWorldObject, IInvulnarable
    {
        private const int InitialNinjaAttackPoints = 0;
        private const int InitialNinjaDefensePoints = int.MaxValue;
        private const int InitialNinjaHitPoints = 1;

        private int attackPoints;

        public Ninja(string name, Point position, int owner)
            : base(name, position, owner)
        {
            this.AttackPoints = InitialNinjaAttackPoints;
            this.HitPoints = InitialNinjaHitPoints;
        }

        public int AttackPoints
        {
            get
            {
                return this.attackPoints;
            }

            private set
            {
                this.attackPoints = value;
            }
        }

        public int DefensePoints
        {
            get
            {
                return InitialNinjaDefensePoints;
            }
        }
        public bool IsInvulnarable
        {
            get
            {
                return true;
            }
        }

        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            var availableTargetsSortedByHitPoints = availableTargets.OrderBy(t => t.HitPoints).ToList();

            for (int i = 0; i < availableTargetsSortedByHitPoints.Count; i++)
            {
                if (availableTargetsSortedByHitPoints[i].Owner != this.Owner
                    && availableTargetsSortedByHitPoints[i].Owner != 0
                    && availableTargetsSortedByHitPoints[i] as IInvulnarable == null)
                {
                    return i;
                }
            }

            return -1;
        }

        public bool TryGather(IResource resource)
        {
            if (resource.Type == ResourceType.Lumber)
            {
                this.AttackPoints += resource.Quantity;
                return true;
            }
            else if (resource.Type == ResourceType.Stone)
            {
                this.AttackPoints += resource.Quantity * 2;
                return true;
            }

            return false;
        }
    }
}
