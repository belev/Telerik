namespace Exam.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Exam.Data.Migrations;
    using Exam.Models;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class BullsAndCowsContext : IdentityDbContext<User>, IBullsAndCowsContext
    {
        private const string ConnectionName = "BullsAndCowsConnection";

        public BullsAndCowsContext()
            : base(ConnectionName)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BullsAndCowsContext, Configuration>());
        }

        public static BullsAndCowsContext Create()
        {
            return new BullsAndCowsContext();
        }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public IDbSet<Game> Games { get; set; }
        
        public IDbSet<Guess> Guesses { get; set; }
    }
}