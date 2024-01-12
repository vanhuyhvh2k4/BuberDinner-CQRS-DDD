using System;
using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Menu.ValueObjects
{
	public sealed class MenuSectionId : ValueObject
	{
		public Guid Value { get; set; }

        public MenuSectionId(Guid value)
        {
            Value = value;
        }

        public static MenuSectionId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public override IEnumerable<object> GetQualtityComponents()
        {
            yield return Value;
        }
    }
}

