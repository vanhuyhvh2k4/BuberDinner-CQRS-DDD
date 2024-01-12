using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.MenuReview.ValueObjects
{
    public class MenuReviewId : ValueObject
	{
        public Guid Value { get; set; }

        public MenuReviewId(Guid value)
        {
            Value = value;
        }

        public static MenuReviewId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public override IEnumerable<object> GetQualtityComponents()
        {
            yield return Value;
        }
    }
}

