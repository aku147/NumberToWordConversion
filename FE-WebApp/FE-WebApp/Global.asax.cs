using FE_WebApp.Implementation;
using FE_WebApp.Interfaces;
using System.Web.Mvc;
using System.Web.Routing;
using Unity;
using Unity.Mvc5;

namespace FE_WebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //Creating container with instances so that can be injected as dependency wherever required
            var container = new UnityContainer();

            //Registering the implementations
            container.RegisterType<IServiceAccess, ServiceAccess>();
            container.RegisterType<ILogger, FileLogger>();

            //Setting the Resolver to Unity instead of default resolver
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            //Configures the log4net logging
            log4net.Config.XmlConfigurator.Configure();
        }
    }
}
