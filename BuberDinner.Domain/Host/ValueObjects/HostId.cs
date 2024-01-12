using System;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Domain.Host.ValueObjects
{
	public class HostId : ValueObject
	{
        public Guid Value { get; set; }

        public HostId(Guid value)
        {
            Value = value;
        }

        public static HostId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public override IEnumerable<object> GetQualtityComponents()
        {
            yield return Value;
        }
    }
}

