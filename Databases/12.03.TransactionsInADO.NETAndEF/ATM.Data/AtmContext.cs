namespace ATM.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using ATM.Models;
    using ATM.Data.Migrations;

    public class AtmContext : DbContext
    {
        const string AtmDatabaseName = "ATM";

        public AtmContext()
            : base(AtmDatabaseName)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AtmContext, Configuration>());
        }

        public DbSet<CardAccount> CardAccounts { get; set; }

        public DbSet<TransactionHistory> TransactionHistories { get; set; }
    }
}
