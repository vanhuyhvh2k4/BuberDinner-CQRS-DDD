using BuberDinner.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Authentication.Commands.Register
{
    public record RegisterCommand(
        string firstName,
        string lastName,
        string email,
        string password) : IRequest<ErrorOr<AuthenticationResult>>;
}

