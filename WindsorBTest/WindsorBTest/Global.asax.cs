using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WindsorBTest
{
    using Castle.Facilities.TypedFactory;
    using Castle.Windsor;
    using Castle.Windsor.Installer;

    using WindsorBTest.Core.Web.Castle;

    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        private static IWindsorContainer container;

        protected static IWindsorContainer InitializeServiceLocator()
        {
            IWindsorContainer cont = new WindsorContainer();

            cont.Kernel.AddFacility<TypedFactoryFacility>();

            var controllerFactory = new WindsorControllerFactory(cont.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);

            // ServiceLocator.SetLocatorProvider(() => new WindsorServiceLocator(cont));

            return cont;
        }

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{*favicon}", new { favicon = @"(.*/)?favicon.ico(/.*)?" });

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            container = InitializeServiceLocator();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_End()
        {
            container.Dispose();
        }
    }
}