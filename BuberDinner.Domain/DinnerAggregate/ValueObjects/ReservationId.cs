using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.DinnerAggregate.ValueObjects
{
    public class ReservationId : ValueObject
    {
        public Guid Value { get; protected set; }

        private ReservationId(Guid value)
        {
            Value = value;
        }

        public static ReservationId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public static ReservationId Create(Guid value)
        {
            return new(value);
        }

        public override IEnumerable<object> GetEqualtityComponents()
        {
            yield return Value;
        }
    }
}

