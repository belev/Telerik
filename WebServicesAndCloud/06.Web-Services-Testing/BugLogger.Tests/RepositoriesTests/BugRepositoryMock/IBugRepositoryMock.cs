namespace BugLogger.Tests.RepositoriesTests.BugRepositoryMock
{
    using BugLogger.Data.Repositories;
    using BugLogger.Models;

    public interface IBugRepositoryMock
    {
        IGenericRepository<Bug> BugsRepository { get; }
    }
}