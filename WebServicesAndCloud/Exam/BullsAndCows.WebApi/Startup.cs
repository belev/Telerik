namespace Exam.WebApi
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Web.Http;
    using Exam.Data;
    using Microsoft.Owin;
    using Ninject;
    using Ninject.Web.Common.OwinHost;
    using Ninject.Web.WebApi.OwinHost;
    using Owin;
    using Exam.WebApi.Infrastructure;
    using Exam.GameLogic;

    [assembly: OwinStartup(typeof(Startup))]

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            app.UseNinjectMiddleware(CreateKernel).UseNinjectWebApi(GlobalConfiguration.Configuration);

        }

        private static StandardKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            RegisterMappings(kernel);
            return kernel;
        }
        private static void RegisterMappings(StandardKernel kernel)
        {
            kernel.Bind<IBullsAndCowsData>().To<BullsAndCowsData>().WithConstructorArgument("context", c => new BullsAndCowsContext());

            kernel.Bind<IGameResultValidator>().To<GameResultValidator>();

            kernel.Bind<IUserIdProvider>().To<UserIdProvider>();
        }
    }
}