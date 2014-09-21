namespace BugLogger.Tests.RepositoriesTests.BugRepositoryMock
{
    using BugLogger.Data.Repositories;
    using BugLogger.Models;
    using System;
    using System.Collections.Generic;

    public abstract class BugRepositoryMock : IBugRepositoryMock
    {
        public BugRepositoryMock()
        {
            this.PopulateFakeBugsData();
            this.ArrangeBugsRepositoryMock();
        }

        public IGenericRepository<Bug> BugsRepository { get; protected set; }

        public ICollection<Bug> FakeBugs { get; set; }

        protected abstract void ArrangeBugsRepositoryMock();

        private void PopulateFakeBugsData()
        {
            this.FakeBugs = new List<Bug>
            {
                new Bug { BugId = 1 ,Text = "Test bug 1", Status = BugStatus.Pending, LogDate = new DateTime(2000, 2, 2) },
                new Bug { BugId = 2 ,Text = "Test bug 2", Status = BugStatus.Fixed, LogDate = new DateTime(2012, 1, 6) },
                new Bug { BugId = 3 ,Text = "Test bug 3", Status = BugStatus.Pending, LogDate = new DateTime(2014, 10, 11) },
                new Bug { BugId = 4 ,Text = "Test bug 4", Status = BugStatus.Pending, LogDate = new DateTime(2014, 10, 10) },
            };
        }
    }
}