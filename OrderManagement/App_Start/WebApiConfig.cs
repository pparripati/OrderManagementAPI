using OrderManagement.ExceptionHandlers;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace OrderManagement
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Register Global exception handler
            config.Services.Replace(typeof(IExceptionHandler), new UnhandledExceptionHandler());
            
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
