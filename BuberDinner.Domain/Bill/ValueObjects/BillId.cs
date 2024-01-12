using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Bill.ValueObjects
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

        public override IEnumerable<object> GetEqualtityComponents()
        {
            yield return Value;
        }
    }
}

