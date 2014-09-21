namespace BugLogger.Tests.IntegrationTests
{
    using System;
    using System.Net;
    using BugLogger.Data.Repositories;
    using BugLogger.Models;
    using BugLogger.Services.Models;
    using BugLogger.Tests.RepositoriesTests.BugRepositoryMock;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class BugsControllerIntegrationTests
    {
        private static Random rand = new Random();
        private string inMemoryServerUrl = "http://localhost:12345/";

        private IGenericRepository<Bug> repository;
        private InMemoryHttpServer<Bug> server;

        public BugsControllerIntegrationTests()
            : this(new MoqBugRepositoryMock())
        {
        }

        public BugsControllerIntegrationTests(IBugRepositoryMock mockedRepository)
        {
            this.repository = mockedRepository.BugsRepository;
        }

        [TestInitialize]
        public void TestInit()
        {
            this.server = new InMemoryHttpServer<Bug>(inMemoryServerUrl, repository);
        }

        [TestMethod]
        public void GetAll_WhenBugsInDb_ShouldReturnStatusOkRequestResultAndNonEmptyContent()
        {
            var response = this.server.CreateGetRequest("api/bugs/all");
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void PostNewBug_WhenTextIsValid_ShouldReturnOkRequestResult()
        {
            var bug = this.GetValidBug();
            var response = server.CreatePostRequest("/api/bugs/create", bug);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public void PostNewBug_WhenTextIsNull_ShouldReturnBadRequestResult()
        {
            var bug = new Bug() { Text = null };
            var response = server.CreatePostRequest("api/bugs/create", bug);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void PostNewBug_WhenTextEmpty_ShouldReturnBadRequestResult()
        {
            var bug = new Bug() { Text = string.Empty };
            var response = server.CreatePostRequest("api/bugs/create", bug);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void PutNewBug_WhenIdIsNotValid_ShouldReturnNotFound()
        {
            var bug = this.GetValidBug();
            var bugId = 15;
            var response = server.CreatePutRequest("api/bugs/update" + bugId, bug);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        //[TestMethod]
        //public void PutNewBug_WhenIdValid_ShouldReturnOk()
        //{
        //    var bug = this.GetValidBug();
        //    var bugId = 1;
        //    var response = server.CreatePutRequest("api/bugs/update" + bugId, bug);

        //    Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        //}

        [TestMethod]
        public void AfterDate_ShouldReturnOkAndAllBugsAfterDate()
        {
            var response = server.CreateGetRequest("api/bugs/afterDate?afterdate=02.02.2013");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void AfterDateInFutre_ShouldReturnOkAndEmptyContent()
        {
            var response = server.CreateGetRequest("api/bugs/afterDate?afterdate=02.02.2020");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void ByValidStatus_ShouldReturnOkAndNonEmptyContent()
        {
            var response = server.CreateGetRequest("api/bugs/bystatus?status=pending");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void ByInvalidStatus_ShouldReturnOkAndNullContent()
        {
            var response = server.CreateGetRequest("api/bugs/bystatus?status=invalidstatus");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNull(response.Content);
        }

        private BugModel GetValidBug()
        {
            return new BugModel()
            {
                Text = "New Bug #" + rand.Next(1000, 2000),
                Status = BugStatus.ForTesting
            };
        }
    }
}