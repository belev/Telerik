namespace BugLogger.Data
{
    using System.Data.Entity;
    using BugLogger.Data.Migrations;
    using BugLogger.Models;

    public class BugLoggerDbContext : DbContext, IBugLoggerDbContext
    {
        private const string ConnectionName = "BugLoggerConnection";

        public BugLoggerDbContext()
            : base(ConnectionName)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BugLoggerDbContext, Configuration>());
        }

        public virtual IDbSet<Bug> Bugs { get; set; }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }
    }
}