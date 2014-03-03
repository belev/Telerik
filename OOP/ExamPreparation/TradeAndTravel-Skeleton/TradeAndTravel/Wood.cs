namespace TradeAndTravel
{
    public class Wood : Item
    {
        private const int GeneralWoodValue = 2;
        private const string DropInteraction = "drop";

        public Wood(string name, Location location = null)
            : base(name, GeneralWoodValue, ItemType.Wood, location)
        {
        }

        public override void UpdateWithInteraction(string interaction)
        {
            if (interaction == DropInteraction)
            {
                if (this.Value > 0)
                {
                    this.Value--;
                }
            }
        }
    }
}
