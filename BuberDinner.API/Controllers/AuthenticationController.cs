using BuberDinner.Application.Services.Authentication.Commands;
using BuberDinner.Application.Services.Authentication.Common;
using BuberDinner.Application.Services.Authentication.Queries;
using BuberDinner.Contracts.Authentication;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BuberDinner.API.Controllers
{
    [Route("api/")]
    //[ErrorHandlingFilter]
    public class AuthenticationController : ApiController
    {
        private readonly IAuthenticationCommandService _authenticationCommandService;
        private readonly IAuthenticationQueryService _authenticationQueryService;

        public AuthenticationController(IAuthenticationCommandService authenticationService, IAuthenticationQueryService authenticationQueryService)
        {
            _authenticationCommandService = authenticationService;
            _authenticationQueryService = authenticationQueryService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            ErrorOr<AuthenticationResult> authResult = _authenticationCommandService.Register(
                request.FirstName,
                request.LastName,
                request.Email,
                request.Password);

            return authResult.Match(
                authResult => Ok(MapAuthResult(authResult)),
                errors => Problem(errors)
                );
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            ErrorOr<AuthenticationResult> authResult = _authenticationQueryService.Login(
                request.Email,
                request.Password);

            return authResult.Match(
                authResult => Ok(MapAuthResult(authResult)),
                errors => Problem(errors)
                );
        }

        private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
        {
            return new AuthenticationResponse(
                authResult.User.Id,
                authResult.User.FirstName,
                authResult.User.LastName,
                authResult.User.Email,
                authResult.Token);
        }
    }
}

