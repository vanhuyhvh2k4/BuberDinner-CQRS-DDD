using System;
using BuberDinner.Application.Common.Interfaces.Services;

namespace BuberDinner.Infrashstructure.Services
{
    public class DateTimeProvider : IDateTimeProvider
	{
        public DateTime UtcNow => DateTime.UtcNow;
    }
}

