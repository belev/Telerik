namespace BugLogger.Tests.RepositoriesTests.BugRepositoryMock
{
    using System;
    using System.Linq;
    using BugLogger.Data.Repositories;
    using BugLogger.Models;
    using Moq;

    public class MoqBugRepositoryMock : BugRepositoryMock, IBugRepositoryMock
    {
        public MoqBugRepositoryMock()
            : base()
        {

        }

        protected override void ArrangeBugsRepositoryMock()
        {
            var mockedBugRepository = new Mock<IGenericRepository<Bug>>();
            mockedBugRepository.Setup(x => x.Add(It.IsAny<Bug>())).Callback<Bug>(b => this.AddToFakeBugs(b));
            mockedBugRepository.Setup(x => x.All()).Returns(this.FakeBugs.AsQueryable());
            mockedBugRepository.Setup(x => x.Update(It.IsAny<Bug>())).Callback<Bug>(b => this.Update(b));
            mockedBugRepository.Setup(x => x.Delete(It.IsAny<Bug>())).Callback<Bug>(b => this.DeleteBug(b));
            mockedBugRepository.Setup(x => x.SaveChanges()).Verifiable();

            this.BugsRepository = mockedBugRepository.Object;
        }

        private void AddToFakeBugs(Bug bug)
        {
            this.FakeBugs.Add(bug);
        }

        private void Update(Bug bug)
        {
            var bugToUpdate = this.FakeBugs.Where(b => b.BugId == bug.BugId).FirstOrDefault();

            if (bugToUpdate == null)
            {
                throw new ArgumentException("Bug with this id does not exists.");
            }

            bugToUpdate.Text = bug.Text;
        }

        private void DeleteBug(Bug bug)
        {
            var bugToDelete = this.FakeBugs.Where(b => b.BugId == bug.BugId).FirstOrDefault();

            if (bugToDelete == null)
            {
                throw new ArgumentException("Bug with this id does not exists.");
            }

            this.FakeBugs.Remove(bugToDelete);
        }
    }
}