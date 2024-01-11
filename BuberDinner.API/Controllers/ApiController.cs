using ErrorOr;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BuberDinner.API.Controllers
{
    [ApiController]
    public class ApiController : Controller
    {
        protected IActionResult Problem(List<Error> errors)
        {
            var firstError = errors[0];

            var statusCode = firstError.Type switch
            {
                ErrorType.Conflict => StatusCodes.Status409Conflict,
                ErrorType.Validation => StatusCodes.Status400BadRequest,
                ErrorType.NotFound => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError
            };

            return Problem(statusCode: statusCode, title: firstError.Description);
        }
    }
}

