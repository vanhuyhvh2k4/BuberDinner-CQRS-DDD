using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.BillAggregate.ValueObjects
{
    public class BillId : ValueObject
    {
        public Guid Value { get; }

        public BillId(Guid value)
        {
            Value = value;
        }

        public static BillId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public static BillId Create(Guid value)
        {
            return new(value);
        }

        public override IEnumerable<object> GetEqualtityComponents()
        {
            yield return Value;
        }
    }
}

