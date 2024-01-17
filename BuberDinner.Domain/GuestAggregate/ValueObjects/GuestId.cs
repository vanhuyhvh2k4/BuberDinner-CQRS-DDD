using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.GuestAggregate.ValueObjects
{
    public class GuestId : AggregateRootId<Guid>
    {
        public override Guid Value { get; protected set; }

        private GuestId(Guid value)
        {
            Value = value;
        }

        public static GuestId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public static GuestId Create(Guid value)
        {
            return new(value);
        }

        public override IEnumerable<object> GetEqualtityComponents()
        {
            yield return Value;
        }
    }
}

