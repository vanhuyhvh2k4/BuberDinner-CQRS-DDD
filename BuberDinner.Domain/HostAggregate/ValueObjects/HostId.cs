using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.HostAggregate.ValueObjects
{
    public class HostId : AggregateRootId<Guid>
    {
        public override Guid Value { get; protected set; }

        private HostId(Guid value)
        {
            Value = value;
        }

        public static HostId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public static HostId Create(Guid value)
        {
            return new(value);
        }
         
        public override IEnumerable<object> GetEqualtityComponents()
        {
            yield return Value;
        }
    }
}

