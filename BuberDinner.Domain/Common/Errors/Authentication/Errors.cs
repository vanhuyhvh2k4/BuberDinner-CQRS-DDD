using System;
using ErrorOr;

namespace BuberDinner.Domain.Common.Errors.Authentication
{
	public static partial class Errors
	{
		public static class AuthenticationError
		{
            public static Error InvalidCredentials = Error.Validation(
                code: "Authentication.InvalidCredentials",
                description: "Invalid credentials.");
        }
	}
}

