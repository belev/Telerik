namespace Exam.WebApi.Controllers
{
    using System.Web.Http;
    using Exam.Data;

    public class BaseApiController : ApiController
    {
        protected BaseApiController(IBullsAndCowsData data)
        {
            this.Data = data;
        }

        protected IBullsAndCowsData Data { get; private set; }
    }
}
