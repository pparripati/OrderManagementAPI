using Newtonsoft.Json;
using OrderManagement.HttpActionResults;
using System.Web.Http.ExceptionHandling;

namespace OrderManagement.ExceptionHandlers
{
    public class UnhandledExceptionHandler : ExceptionHandler
    {
        /// <summary>
        /// Show complete error detail in debug mode other wise show a generic error message
        /// </summary>
        /// <param name="context"></param>
        public override void Handle(ExceptionHandlerContext context)
        {
#if DEBUG
            var content = JsonConvert.SerializeObject(context.Exception);
#else
            var content = @"{ ""message"" : ""A unhandled exception has occured"" }";
#endif
            context.Result = new ErrorContentResult(content, "application/json", context.Request);
        }
    }
}