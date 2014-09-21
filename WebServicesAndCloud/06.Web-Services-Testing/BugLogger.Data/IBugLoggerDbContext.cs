namespace BugLogger.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using BugLogger.Models;

    public interface IBugLoggerDbContext
    {
        IDbSet<Bug> Bugs { get; set; }

        void SaveChanges();

        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;
    }
}