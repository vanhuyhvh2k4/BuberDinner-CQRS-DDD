using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Application.Common.Errors;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BuberDinner.API.Controllers
{
    public class ErrorController : Controller
    {
        [Route("/error")]
        public IActionResult Error()
        {
            Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

            var (statuscode, message) = exception switch
            {
                IServiceException serviceException  => ((int)serviceException.StatusCode, serviceException.ErrorMessage),
                                        _ => (StatusCodes.Status500InternalServerError, "An unexpected error occurred."),
            };
            return Problem(statusCode: statuscode, title: message);
        }
    }
}

