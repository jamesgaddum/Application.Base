using Application.Base.Application;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Application.Base.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ErrorsController : ControllerBase
    {
        [HttpPost]
        [Route("/error")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();

            if (context.Error is ValidationException)
            {
                return StatusCode(400, new ValidationProblemDetails((context.Error as ValidationException).Failures));
            }

            return Problem(detail: context.Error.Message);
        }

        [HttpPost]
        [Route("/dev-error")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult DevelopmentError()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();

            if (context.Error is ValidationException)
            {
                return StatusCode(400, new ValidationProblemDetails((context.Error as ValidationException).Failures));
            }

            return Problem(title: context.Error.Message, detail: context.Error.StackTrace);
        }
    }
}
