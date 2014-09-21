namespace BugLogger.Tests.RepositoriesTests
{
    using System;
    using System.Linq;
    using BugLogger.Models;
    using BugLogger.Tests.RepositoriesTests.BugRepositoryMock;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class BugGenericRepositoryTestsWithMock
    {
        private IBugRepositoryMock mockedRepo;

        public BugGenericRepositoryTestsWithMock()
            : this(new MoqBugRepositoryMock())
        {

        }

        public BugGenericRepositoryTestsWithMock(IBugRepositoryMock bugsRepository)
        {
            this.mockedRepo = bugsRepository;
        }


        [TestMethod]
        public void All_ReturnAllBugs()
        {
            var count = this.mockedRepo.BugsRepository.All().Count();

            Assert.AreEqual(4, count);
        }

        [TestMethod]
        public void AddingBug_ShouldIncreaseBugsCount()
        {
            var bug = this.GetValidTestBug();
            var expectedBugsCount = this.mockedRepo.BugsRepository.All().Count() + 1;

            this.mockedRepo.BugsRepository.Add(bug);

            Assert.AreEqual(expectedBugsCount, this.mockedRepo.BugsRepository.All().Count());
        }

        [TestMethod]
        public void UpdatingExistingBug_ShouldReturnBug()
        {
            var bug = new Bug()
            {
                BugId = 1,
                Text = "updated"
            };

            this.mockedRepo.BugsRepository.Update(bug);

            Assert.AreEqual(bug.Text, this.mockedRepo.BugsRepository.All().First().Text);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UpdatingUnexistingBug_ShouldThrowArgumentException()
        {
            var bug = new Bug()
            {
                BugId = 11,
                Text = "updated"
            };
            this.mockedRepo.BugsRepository.Update(bug);
        }

        [TestMethod]
        public void DeleteExistingBug_ShouldDecreaseBugsCount()
        {
            var bug = new Bug()
            {
                BugId = 1
            };

            var expectedCount = this.mockedRepo.BugsRepository.All().Count() - 1;

            this.mockedRepo.BugsRepository.Delete(bug);

            Assert.AreEqual(expectedCount, this.mockedRepo.BugsRepository.All().Count());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeletingUnexistingBug_ShouldThrowArgumentException()
        {
            var bug = new Bug()
            {
                BugId = 11,
                Text = "deleted"
            };
            this.mockedRepo.BugsRepository.Delete(bug);
        }

        private Bug GetValidTestBug()
        {
            var bug = new Bug()
            {
                Text = "Test New bug",
                LogDate = DateTime.Now,
                Status = BugStatus.Pending
            };
            return bug;
        }
    }
}