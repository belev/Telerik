namespace ATM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ATM.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<AtmContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(AtmContext context)
        {
            SeedCardAccounts(context);
        }

        private static void SeedCardAccounts(AtmContext context)
        {
            if (context.CardAccounts.Any())
            {
                return;
            }

            context.CardAccounts.Add(new CardAccount
            {
                CardNumber = 1234567890,
                CardPin = 1111,
                CardCash = 15000M
            });

            context.CardAccounts.Add(new CardAccount
            {
                CardNumber = 1234567891,
                CardPin = 2222,
                CardCash = 1000M
            });

            context.CardAccounts.Add(new CardAccount
            {
                CardNumber = 1234567892,
                CardPin = 3333,
                CardCash = 3500M
            });

            context.CardAccounts.Add(new CardAccount
            {
                CardNumber = 1234567893,
                CardPin = 4444,
                CardCash = 200M
            });

            context.CardAccounts.Add(new CardAccount
            {
                CardNumber = 1234567894,
                CardPin = 5555,
                CardCash = 12200M
            });

            context.CardAccounts.Add(new CardAccount
            {
                CardNumber = 1234567895,
                CardPin = 6666,
                CardCash = 56789M
            });
        }
    }
}
