using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.MenuReviewAggregate.ValueObjects
{
    public class MenuReviewId : ValueObject
    {
        public Guid Value { get; set; }

        private MenuReviewId(Guid value)
        {
            Value = value;
        }

        public static MenuReviewId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualtityComponents()
        {
            yield return Value;
        }
    }
}

