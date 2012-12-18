
namespace Naskar.Documents.Web
{
    using System.Web.Mvc;
    using System.Web.Routing;

    using FluentValidation.Mvc;

    using Naskar.Architecture.Web.Interceptors;

    using Spring.Web.Mvc;

    public class MvcApplication : SpringMvcApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new ValidateModelStateInterceptor());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            //InputBuilder.BootStrap();
            FluentValidationModelValidatorProvider.Configure();
        }
    }
}