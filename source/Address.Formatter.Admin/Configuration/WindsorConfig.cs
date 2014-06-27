using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using Address.Formatter.Admin.Api.Formats;
using Address.Formatter.Admin.Data;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace Address.Formatter.Admin.Configuration
{
    public static class WindsorConfig
    {
        public static IWindsorContainer Init(
            this IWindsorContainer container,
            HttpConfiguration configuration)
        {
            RegisterServices(container);
            RegisterEF(container);

            RegisterWebApi(container, configuration);

            return container;
        }

        static void RegisterEF(IWindsorContainer container)
        {
            container.Register(
                Component.For<DataContext, DataContext>()
                         .LifestylePerWebRequest()
                );
        }

        static void RegisterServices(
            IWindsorContainer container)
        {
            container.Register(
                Component.For<IFormatStore, FormatStore>()
                         .LifestyleTransient()
                );
        }

        static void RegisterWebApi(
            IWindsorContainer container,
            HttpConfiguration configuration)
        {
            container.Register(
                Classes.FromThisAssembly()
                       .BasedOn<ApiController>()
                       .LifestyleTransient()
                );

            configuration.Services.Replace(
                typeof (IHttpControllerActivator),
                new ServiceHttpControllerActivator(
                    t => (IHttpController) container.Resolve(t),
                    container.Release)
                );
        }
    }
}