using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Dinner.ValueObjects
{
    public class DinnerId : ValueObject
	{
        public Guid Value { get; set; }

        public DinnerId(Guid value)
        {
            Value = value;
        }

        public static DinnerId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public override IEnumerable<object> GetQualtityComponents()
        {
            yield return Value;
        }
    }
}

