namespace BugLogger.Tests.RepositoriesTests
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Transactions;
    using BugLogger.Data;
    using BugLogger.Data.Repositories;
    using BugLogger.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class BugGenericRepositoryTests
    {
        private IBugLoggerDbContext context;
        private IGenericRepository<Bug> bugsRepository;
        private TransactionScope transactionScope;

        [TestInitialize]
        public void TestInit()
        {
            this.context = new BugLoggerDbContext();
            this.bugsRepository = new GenericRepository<Bug>(this.context);
            this.transactionScope = new TransactionScope();
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            this.transactionScope.Dispose();
        }

        [TestMethod]
        public void Find_WhenObjectIsInDb_ShouldReturnObject()
        {
            var bug = this.GetValidTestBug();

            this.context.Bugs.Add(bug);
            this.context.SaveChanges();

            var bugInDb = this.bugsRepository.All().FirstOrDefault(b => b.BugId == bug.BugId);

            Assert.IsNotNull(bugInDb);
            Assert.AreEqual(bug.Text, bugInDb.Text);
            Assert.AreEqual(bug.Status, bugInDb.Status);
            Assert.AreEqual(bug.LogDate, bugInDb.LogDate);
        }

        [TestMethod]
        public void AddBug_WhenBugIsValid_ShouldAddToDb()
        {
            var bug = this.GetValidTestBug();

            this.bugsRepository.Add(bug);
            this.bugsRepository.SaveChanges();

            var bugInDb = this.bugsRepository.All().FirstOrDefault(b => b.BugId == bug.BugId);

            Assert.IsNotNull(bugInDb);
            Assert.AreEqual(bug.Text, bugInDb.Text);
            Assert.AreEqual(bug.Status, bugInDb.Status);
            Assert.AreEqual(bug.LogDate, bugInDb.LogDate);
        }

        [TestMethod]
        public void UpdateBug_WhenUpdateBug_ShouldUpdateTheBug()
        {
            var bug = this.GetValidTestBug();

            this.bugsRepository.Add(bug);
            this.bugsRepository.SaveChanges();

            bug.Text = "updated bug text";

            this.bugsRepository.Update(bug);
            this.bugsRepository.SaveChanges();

            var updatedBugInDb = this.bugsRepository.All().FirstOrDefault(b => b.BugId == bug.BugId);

            Assert.IsNotNull(updatedBugInDb);
            Assert.AreEqual(bug.Text, updatedBugInDb.Text);
        }

        [TestMethod]
        public void DeleteBug_WhenBugIsDeleted_NothingShouldBeFound()
        {
            var bug = this.GetValidTestBug();

            this.bugsRepository.Add(bug);
            
            this.bugsRepository.Delete(bug);

            var bugInDb = this.bugsRepository.All().FirstOrDefault(b => b.BugId == bug.BugId);
            Assert.IsNull(bugInDb);
        }

        [TestMethod]
        public void DetachBug_WhenDetachBug_StateShouldBeDetached()
        {
            var bug = this.GetValidTestBug();

            this.bugsRepository.Add(bug);
            this.bugsRepository.Detach(bug);

            var bugEntry = this.context.Entry(bug);

            Assert.AreEqual(EntityState.Detached, bugEntry.State);
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