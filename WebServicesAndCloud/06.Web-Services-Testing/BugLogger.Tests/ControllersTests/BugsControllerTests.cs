namespace BugLogger.Tests.ControllersTests
{
    using System;
    using System.Linq;
    using System.Web.Http.Results;
    using BugLogger.Data.Repositories;
    using BugLogger.Models;
    using BugLogger.Services.Controllers;
    using BugLogger.Services.Models;
    using BugLogger.Tests.RepositoriesTests.BugRepositoryMock;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class BugsControllerTests
    {
        private IGenericRepository<Bug> repository;
        private BugsController controller;

        public BugsControllerTests()
            : this(new MoqBugRepositoryMock())
        {
        }

        public BugsControllerTests(IBugRepositoryMock mockedRepository)
        {
            this.repository = mockedRepository.BugsRepository;
        }

        [TestInitialize]
        public void TestInit()
        {
            this.controller = new BugsController(this.repository);
        }

        [TestMethod]
        public void All_ShouldReturnHttpStatusCode200()
        {
            var actionResult = this.controller.All();

            var contentResult = actionResult as OkNegotiatedContentResult<IQueryable<BugModel>>;

            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(4, contentResult.Content.Count());
        }

        [TestMethod]
        public void Create_ShouldReturnSameBugModel()
        {
            var bug = new BugModel()
            {
                Text = "test bug model"
            };

            var createdBug = this.controller.Create(bug) as OkNegotiatedContentResult<BugModel>;

            Assert.AreEqual(bug.Text, createdBug.Content.Text);
        }

        [TestMethod]
        public void CreateInvalidBug_ShouldReturnBadRequest()
        {
            var bug = new BugModel();

            var badRequest = this.controller.Create(bug);

            Assert.IsInstanceOfType(badRequest, typeof(BadRequestErrorMessageResult));
        }

        [TestMethod]
        public void UpdateValidBugStatus_ShouldReturnTheUpdatedBug()
        {
            int bugId = 2;
            var updatedBugInfo = new BugModel()
            {
                Status = BugStatus.ForTesting
            };

            var actionResult = this.controller.Update(bugId, updatedBugInfo);
            var contentResult = actionResult as OkNegotiatedContentResult<BugModel>;

            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(updatedBugInfo.Status, contentResult.Content.Status);
        }

        [TestMethod]
        public void UpdateInvalidBugStatus_ShouldReturnBadRequest()
        {
            int bugId = 5;
            var updatedBugInfo = new BugModel()
            {
                Status = BugStatus.ForTesting
            };

            var badRequest = this.controller.Update(bugId, updatedBugInfo);

            Assert.IsInstanceOfType(badRequest, typeof(BadRequestErrorMessageResult));
        }

        [TestMethod]
        public void AfterDate_ShouldReturnAllBugsAfterTheDateGiven()
        {
            string date = "02.02.2013";

            var actionResult = this.controller.AfterDate(date);
            var contentResult = actionResult as OkNegotiatedContentResult<IQueryable<BugModel>>;

            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(2, contentResult.Content.Count());
        }

        [TestMethod]
        public void AfterDateInFuture_ShouldReturnEmptyCollection()
        {
            string date = "02.02.2020";

            var actionResult = this.controller.AfterDate(date);
            var contentResult = actionResult as OkNegotiatedContentResult<IQueryable<BugModel>>;

            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(0, contentResult.Content.Count());
        }

        [TestMethod]
        public void ByStatus_WhenStatusDoesNotExists_ShouldReturnOkResult()
        {
            string status = "invalidStatus";

            var actionResult = this.controller.ByStatus(status);

            Assert.IsInstanceOfType(actionResult, typeof(OkResult));
        }

        [TestMethod]
        public void ByStatus_WhenStatusIsValid_ShouldReturnAllBugsWithTheStatus()
        {
            // pending status
            string status = "pending";

            var actionResult = this.controller.ByStatus(status);
            var contentResult = actionResult as OkNegotiatedContentResult<IQueryable<BugModel>>;

            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(3, contentResult.Content.Count());

            // fixed status
            status = "fixed";

            actionResult = this.controller.ByStatus(status);
            contentResult = actionResult as OkNegotiatedContentResult<IQueryable<BugModel>>;

            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(1, contentResult.Content.Count());
        }

        [TestMethod]
        public void ByStatus_WhenThereIsNoBugWithThisStatus_ShouldReturnEmptyCollection()
        {
            var status = "assigned";

            var actionResult = this.controller.ByStatus(status);
            var contentResult = actionResult as OkNegotiatedContentResult<IQueryable<BugModel>>;

            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(0, contentResult.Content.Count());
        }
    }
}