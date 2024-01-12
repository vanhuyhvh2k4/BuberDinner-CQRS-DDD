using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.GuestAggregate.ValueObjects;

namespace BuberDinner.Domain.GuestAggregate
{
    public class Guest : AggregateRoot<GuestId>
    {
        public Guest(GuestId guestId) : base(guestId)
        {
        }
    }
}

