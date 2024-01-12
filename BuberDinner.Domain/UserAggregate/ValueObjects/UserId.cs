using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.UserAggregate.ValueObjects
{
    public class UserId : ValueObject
    {
        public Guid Value { get; }

        private UserId(Guid value)
        {
            Value = value;
        }

        public static UserId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualtityComponents()
        {
            yield return Value;
        }
    }
}

