using Application.Base.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Application.Base.WebAPI.Filters
{
    public class ValidationExceptionFilter: ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (!(context.Exception is ValidationException))
            {
                return;
            }

            // string exceptionMessage = string.Empty;

            context.Result = new ProblemDetails
            {
                Detail = "Oh no!"
            } as IActionResult;

            // if (context.Exception.InnerException == null)
            // {
            //     exceptionMessage = context.Exception.Message;
            // }
            // else
            // {
            //     exceptionMessage = context.Exception.InnerException.Message;
            // }
            //We can log this exception message to the file or database.
            // var response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            // {
            //     Content = new StringContent(“An unhandled exception was thrown by service.”),
            //         ReasonPhrase = "Internal Server Error.Please Contact your Administrator."
            // };
            // context.HttpContext.Response.Body = new StreamContent();
            // // context.Response = response;
        }
    }
}
