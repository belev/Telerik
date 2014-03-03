namespace TradeAndTravel
{
    using System;
    using System.Collections.Generic;

    public class ExtendedInteractionManager : InteractionManager
    {
        private const string GatherInteraction = "gather";
        private const string CraftInteraction = "craft";

        // items creation or craft cases
        private const string WeaponCase = "weapon";
        private const string ArmorCase = "armor";
        private const string IronCase = "iron";
        private const string WoodCase = "wood";

        // location creation cases
        private const string MineCase = "mine";
        private const string ForestCase = "forest";

        // person creation case
        private const string MerchantCase = "merchant";

        private const int NumberOfItemTypes = 4;

        public ExtendedInteractionManager()
            : base()
        {
        }

        protected override Item CreateItem(string itemTypeString, string itemNameString, Location itemLocation, Item item)
        {
            switch (itemTypeString)
            {
                case WeaponCase:
                    item = new Weapon(itemNameString, itemLocation);
                    break;
                case IronCase:
                    item = new Iron(itemNameString, itemLocation);
                    break;
                case WoodCase:
                    item = new Wood(itemNameString, itemLocation);
                    break;
                default:
                    item = base.CreateItem(itemTypeString, itemNameString, itemLocation, item);
                    break;
            }

            return item;
        }

        protected override Location CreateLocation(string locationTypeString, string locationName)
        {
            Location location = null;

            switch (locationTypeString)
            {
                case MineCase:
                    location = new Mine(locationName);
                    break;
                case ForestCase:
                    location = new Forest(locationName);
                    break;
                default:
                    location = base.CreateLocation(locationTypeString, locationName);
                    break;
            }

            return location;
        }

        protected override Person CreatePerson(string personTypeString, string personNameString, Location personLocation)
        {
            Person person = null;

            switch (personTypeString)
            {
                case MerchantCase:
                    person = new Merchant(personNameString, personLocation);
                    break;
                default:
                    person = base.CreatePerson(personTypeString, personNameString, personLocation);
                    break;
            }

            return person;
        }

        protected override void HandlePersonCommand(string[] commandWords, Person actor)
        {
            switch (commandWords[1])
            {
                case GatherInteraction:
                    {
                        HandleGatherInteraction(commandWords, actor);
                        break;
                    }
                case CraftInteraction:
                    {
                        HandleCraftInteraction(commandWords, actor);
                        break;
                    }
                default:
                    base.HandlePersonCommand(commandWords, actor);
                    break;
            }
        }

        private void HandleGatherInteraction(string[] commandWords, Person actor)
        {
            var itemsInInventory = actor.ListInventory();
            bool[] hasItemTypes = this.CheckActorInventoryForItem(itemsInInventory);

            if (actor.Location is Forest)
            {
                if (hasItemTypes[2])
                {
                    var gatheredWood = new Wood(commandWords[2], actor.Location);
                    this.AddToPerson(actor, gatheredWood);
                }
            }

            else if (actor.Location is Mine)
            {
                if (hasItemTypes[3])
                {
                    var gatheredIron = new Iron(commandWords[2], actor.Location);
                    this.AddToPerson(actor, gatheredIron);
                }
            }

        }

        private void HandleCraftInteraction(string[] commandWords, Person actor)
        {
            var itemsInInventory = actor.ListInventory();
            bool[] hasItemTypes = this.CheckActorInventoryForItem(itemsInInventory);

            switch (commandWords[2].ToLower())
            {
                case ArmorCase:
                    {
                        if (hasItemTypes[0])
                        {
                            var craftedArmor = new Armor(commandWords[3], actor.Location);
                            this.AddToPerson(actor, craftedArmor);
                        }

                        break;
                    }
                case WeaponCase:
                    {
                        if (hasItemTypes[0] && hasItemTypes[1])
                        {
                            var craftedWeapon = new Weapon(commandWords[3], actor.Location);
                            this.AddToPerson(actor, craftedWeapon);
                        }

                        break;
                    }
                default:
                    break;
            }
        }

        /// <summary>
        /// Check if there is wood or iron in the inventory
        /// Tha array hasItemTypes keeps the information about having iron, wood, weapon or armor in the inventory
        /// If hasItemTypes[0] == true -> it means there is iron in inventory
        /// If hasItemTypes[1] == true -> it means there is wood in inventory
        /// If hasItemTypes[2] == true -> it means there is weapon in inventory
        /// If hasItemTypes[3] == true -> it means there is armor in inventory</summary>
        /// <param name="itemsInInventory"></param>
        /// <returns></returns>
        private bool[] CheckActorInventoryForItem(List<Item> itemsInInventory)
        {
            bool[] hasItemTypes = new bool[NumberOfItemTypes];

            foreach (var item in itemsInInventory)
            {
                if (item is Iron)
                {
                    hasItemTypes[0] = true;
                }

                if (item is Wood)
                {
                    hasItemTypes[1] = true;
                }

                if (item is Weapon)
                {
                    hasItemTypes[2] = true;
                }

                if (item is Armor)
                {
                    hasItemTypes[3] = true;
                }
            }

            return hasItemTypes;
        }
    }
}
