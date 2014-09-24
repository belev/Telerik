namespace Exam.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using Exam.Models;

    public interface IBullsAndCowsContext
    {
        IDbSet<Game> Games { get; set; }

        IDbSet<Guess> Guesses { get; set; }

        void SaveChanges();

        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;
    }
}