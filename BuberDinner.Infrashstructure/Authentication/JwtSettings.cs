﻿using System;
namespace BuberDinner.Infrashstructure.Authentication
{
	public class JwtSettings
	{
		public const string SectionName = "JwtSettings";

		public string Secret { get; init; } = null!;

		public int ExpiryMinutes { get; init; }

		public string Issuer { get; init; } = null!;

		public object Audience { get; init; } = null!;
	}
}
