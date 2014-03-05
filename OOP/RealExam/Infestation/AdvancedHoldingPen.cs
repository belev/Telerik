namespace Infestation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class AdvancedHoldingPen : HoldingPen
    {
        private const string WeaponAddCase = "Weapon";
        private const string AggressionInhibitorAddCase = "AggressionInhibitor";
        private const string HealthInhibitorAddCase = "HealthInhibitor";
        private const string PowerInhibitorAddCase = "PowerInhibitor";
        private const string InfestationSporesAddCase = "InfestationSpores";

        private const string MarineInsertCase = "Marine";
        private const string TankInsertCase = "Tank";
        private const string QueenInsertCase = "Queen";
        private const string ParasiteInsertCase = "Parasite";

        public AdvancedHoldingPen()
            : base()
        {
        }

        protected override void ExecuteAddSupplementCommand(string[] commandWords)
        {
            var unit = this.GetUnit(commandWords[2]);

            switch (commandWords[1])
            {
                case WeaponAddCase:
                    {
                        unit.AddSupplement(new Weapon());
                        break;
                    }
                case AggressionInhibitorAddCase:
                    {
                        unit.AddSupplement(new AggressionInhibitor());
                        break;
                    }
                case HealthInhibitorAddCase:
                    {
                        unit.AddSupplement(new HealthInhibitor());
                        break;
                    }
                case PowerInhibitorAddCase:
                    {
                        unit.AddSupplement(new PowerInhibitor());
                        break;
                    }
                case InfestationSporesAddCase:
                    {
                        unit.AddSupplement(new InfestationSpores());
                        break;
                    }
                default:
                    break;
            }
        }

        protected override void ExecuteInsertUnitCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case MarineInsertCase:
                    {
                        var marine = new Marine(commandWords[2]);
                        this.InsertUnit(marine);
                        break;
                    }
                case TankInsertCase:
                    {
                        var tank = new Tank(commandWords[2]);
                        this.InsertUnit(tank);
                        break;

                    }
                case QueenInsertCase:
                    {
                        var queen = new Queen(commandWords[2]);
                        this.InsertUnit(queen);
                        break;
                    }
                case ParasiteInsertCase:
                    {
                        var parasite = new Parasite(commandWords[2]);
                        this.InsertUnit(parasite);
                        break;
                    }
                default:
                    base.ExecuteInsertUnitCommand(commandWords);
                    break;
            }
        }

        protected override void ProcessSingleInteraction(Interaction interaction)
        {
            switch (interaction.InteractionType)
            {
                case InteractionType.Attack:
                    Unit targetUnit = this.GetUnit(interaction.TargetUnit);
                    var sourceUnit = this.GetUnit(interaction.SourceUnit);

                    if (sourceUnit is Parasite || sourceUnit is Queen)
                    {
                        if (InfestationRequirements.RequiredClassificationToInfest(targetUnit.UnitClassification) == InfestationRequirements.RequiredClassificationToInfest(sourceUnit.UnitClassification))
                        {
                            targetUnit.AddSupplement(new InfestationSpores());
                            return;
                        }
                    }

                    targetUnit.DecreaseBaseHealth(interaction.SourceUnit.Power);
                    break;
                default:
                    break;
            }
        }
    }
}
