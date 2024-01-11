using System;
using ErrorOr;

namespace BuberDinner.Domain.Common.Errors.User
{
	public class Errors
	{
		public static class User
		{
			public static Error DuplicateEmail = Error.Conflict(
                code: "User.DuplicateEmail",
                description: "Email already exists.");
		}
	}
}

