namespace Exam.WebApi.Infrastructure
{
    using System.Threading;
    using Microsoft.AspNet.Identity;

    public class UserIdProvider : IUserIdProvider
    {
        public string GetUserId()
        {
            return Thread.CurrentPrincipal.Identity.GetUserId();
        }
    }
}