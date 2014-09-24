using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Http;
using System.Net.Http;
using System.Web.Http.Routing;
using Exam.Models;
using Exam.Data;
using Telerik.JustMock;
using Exam.WebApi.Controllers;
using Exam.GameLogic;
using Exam.WebApi.Infrastructure;
using System.Threading;
using System.Collections.Generic;

namespace Exam.Tests
{
    [TestClass]
    public class GamesControllerTests
    {
        [TestMethod]
        public void GetScores_ShouldReturnAllUsersSorted()
        {
            var topUsers = new[]
            {
                new User
            {
                UserName = "test1",
                WinsCount = 10,
                LoosesCount = 0
            },
            new User
            {
                UserName = "test2",
                WinsCount = 15,
                LoosesCount = 0
            },
            new User
            {
                UserName = "test3",
                WinsCount = 12,
                LoosesCount = 0
            }
            };

            var repo = Mock.Create<IGenericRepository<User>>();
            Mock.Arrange(() => repo.All())
                .Returns(() => topUsers.AsQueryable());

            var data = Mock.Create<IBullsAndCowsData>();

            Mock.Arrange(() => data.Users)
                .Returns(() => repo);

            var controller = new GamesController(data, new GameResultValidator(), new UserIdProvider(), new Random());
            this.SetupController(controller);

            var actionResult = controller.GetTopScores();

            var response = actionResult.ExecuteAsync(CancellationToken.None).Result;

            var actual = response.Content.ReadAsAsync<IEnumerable<User>>().Result.Select(u => new { Id = u.Id, Username = u.UserName }).ToList();

            var expected = topUsers.OrderByDescending(u => (u.WinsCount * 100 + u.LoosesCount * 15)).Select(u => new { Id = u.Id, Username = u.UserName }).ToList();

            Assert.AreEqual(expected.Count, actual.Count);
            Assert.AreEqual(expected[0].Username, actual[0].Username);
        }

        private void SetupController(ApiController controller)
        {
            string serverUrl = "http://test-url.com";

            //Setup the Request object of the controller
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(serverUrl)
            };
            controller.Request = request;

            //Setup the configuration of the controller
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional });
            controller.Configuration = config;

            //Apply the routes of the controller
            controller.RequestContext.RouteData =
                new HttpRouteData(
                    route: new HttpRoute(),
                    values: new HttpRouteValueDictionary
                    {
                        {
                                "controller",
                                "articles"
                        }
                    });
        }
    }
}