using BuberDinner.Domain.BillAggregate.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.DinnerAggregate.Entities;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.MenuAggregate.ValueObjects;

namespace BuberDinner.Domain.DinnerAggregate
{
    public class Dinner : AggregateRoot<DinnerId>
    {
        private readonly List<Reservation> _reservations = new();

        public string Name { get; private set; }

        public string Description { get; private set; }

        public DateTime StartDateTime { get; private set; }

        public DateTime EndDateTime { get; private set; }

        public DateTime? StartedDateTime { get; private set; }

        public DateTime? EndedDateTime { get; private set; }

        public string Status { get; private set; }

        public bool IsPublic { get; private set; }

        public int MaxGuest { get; private set; }

        public Price Price { get; private set; }

        public HostId HostId { get; private set; }

        public MenuId MenuId { get; private set; }

        public string ImageUrl { get; private set; }

        public Location Location { get; private set; }

        public IReadOnlyList<Reservation> Reservations => _reservations.AsReadOnly();

        public DateTime CreatedDateTime { get; private set; }

        public DateTime UpdatedDateTime { get; private set; }

        private Dinner(
            DinnerId dinnerId,
            string name,
            string description,
            DateTime startDateTime,
            DateTime endDateTime,
            string status,
            bool isPubic,
            int maxGuest,
            Price price,
            HostId hostId,
            MenuId menuId,
            string imageUrl,
            Location location,
            DateTime createdDateTime,
            DateTime updatedDateTime) : base(dinnerId)
        {
            Name = name;
            Description = description;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            Status = status;
            IsPublic = isPubic;
            MaxGuest = maxGuest;
            Price = price;
            HostId = hostId;
            MenuId = menuId;
            ImageUrl = imageUrl;
            Location = location;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static Dinner Create(
            string name,
            string description,
            DateTime startDateTime,
            DateTime endDateTime,
            string status,
            bool isPubic,
            int maxGuest,
            Price price,
            HostId hostId,
            MenuId menuId,
            string imageUrl,
            Location location
            )
        {
            return new(
                DinnerId.CreateUnique(),
                name,
                description,
                startDateTime,
                endDateTime,
                status,
                isPubic,
                maxGuest,
                price,
                hostId,
                menuId,
                imageUrl,
                location,
                DateTime.UtcNow,
                DateTime.UtcNow);
        }

#pragma warning disable CS8618
        private Dinner() { }
#pragma warning restore CS8618
    }
}


