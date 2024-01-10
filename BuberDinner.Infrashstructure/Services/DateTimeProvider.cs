using System;
using BuberDinner.Application.Services.Services;

namespace BuberDinner.Infrashstructure.Services
{
	public class DateTimeProvider : IDateTimeProvider
	{
        public DateTime UtcNow => DateTime.UtcNow;
    }
}

