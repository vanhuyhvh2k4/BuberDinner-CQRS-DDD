using System;
using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Common.ValueObjects
{
	public class Rating : ValueObject
	{
        public double Value { get; }

        private Rating(double value)
		{
            Value = value;
		}

        public static Rating CreateNew(double value)
        {
            return new(value);
        }

        public override IEnumerable<object> GetEqualtityComponents()
        {
            yield return Value;
        }
    }
}

