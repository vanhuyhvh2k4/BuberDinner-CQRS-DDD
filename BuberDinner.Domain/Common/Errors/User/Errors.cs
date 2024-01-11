using System;
using ErrorOr;

namespace BuberDinner.Domain.Common.Errors.User
{
	public partial class Errors
	{
		public static class UserError
		{
			public static Error DuplicateEmail = Error.Conflict(
                code: "User.DuplicateEmail",
                description: "Email already exists.");
		}
	}
}

