namespace AcademyRPG
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Giant : Character, IControllable, IFighter, IGatherer, IWorldObject
    {
        private const int InitialGiantOwnerIndex = 0;
        private const int InitialAttackPoints = 150;
        private const int InitialDefensePoints = 80;
        private const int InitialHitPoints = 200;

        private int gatheringResourceCount;
        private int attackPoints;

        public Giant(string name, Point position)
            : base(name, position, InitialGiantOwnerIndex)
        {
            this.gatheringResourceCount = 0;
            this.HitPoints = InitialHitPoints;
            this.AttackPoints = InitialAttackPoints;
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
                return InitialDefensePoints;
            }
        }

        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            for (int i = 0; i < availableTargets.Count; i++)
            {
                if (availableTargets[i].Owner != 0 && availableTargets[i] as IInvulnarable == null)
                {
                    return i;
                }
            }

            return -1;
        }

        public bool TryGather(IResource resource)
        {
            if (resource.Type == ResourceType.Stone)
            {
                this.gatheringResourceCount++;

                if (this.gatheringResourceCount == 1)
                {
                    this.AttackPoints += 100;
                }
                return true;
            }

            return false;
        }
    }
}
