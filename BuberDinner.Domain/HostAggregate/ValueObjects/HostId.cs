using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.HostAggregate.ValueObjects
{
    public class HostId : ValueObject
    {
        public Guid Value { get; }

        private HostId(Guid value)
        {
            Value = value;
        }

        public static HostId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualtityComponents()
        {
            yield return Value;
        }
    }
}

