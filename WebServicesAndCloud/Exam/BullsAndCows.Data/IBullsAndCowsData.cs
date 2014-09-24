namespace Exam.Data
{
    using Exam.Models;

    public interface IBullsAndCowsData
    {
        IGenericRepository<Game> Games { get; }

        IGenericRepository<User> Users { get; }

        IGenericRepository<Guess> Guesses { get; }

        void SaveChanges();
    }
}