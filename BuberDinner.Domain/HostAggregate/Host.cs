using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.MenuAggregate.ValueObjects;
using BuberDinner.Domain.UserAggregate.ValueObjects;

namespace BuberDinner.Domain.HostAggregate
{
    public class Host : AggregateRoot<HostId>
    {
        public readonly List<MenuId> _menuIds = new();

        public readonly List<DinnerId> _dinnerIds = new();

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string ProfileImage { get; private set; }

        public AverageRating AverageRating { get; private set; }

        public UserId UserId { get; private set; }

        public IReadOnlyList<MenuId> MenuIds => _menuIds.AsReadOnly();

        public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();

        public DateTime CreatedDateTime { get; private set; }

        public DateTime UpdatedDateTime { get; private set; }

        private Host(
            HostId hostId,
            string firstName,
            string lastName,
            string profileImage,
            AverageRating averageRating,
            UserId userId,
            List<MenuId> menuIds,
            List<DinnerId> dinnerIds,
            DateTime createdDateTime,
            DateTime updateDateTime) : base(hostId)
        {
            FirstName = firstName;
            LastName = lastName;
            ProfileImage = profileImage;
            AverageRating = averageRating;
            UserId = userId;
            _menuIds = menuIds;
            _dinnerIds = dinnerIds;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updateDateTime;
        }

        public static Host Create(
            string firstName,
            string lastName,
            string profileImage,
            AverageRating averageRating,
            UserId userId,
            List<MenuId> menuIds,
            List<DinnerId> dinnerIds
            )
        {
            return new(
                HostId.CreateUnique(),
                firstName,
                lastName,
                profileImage,
                averageRating,
                userId,
                menuIds,
                dinnerIds,
                DateTime.UtcNow,
                DateTime.UtcNow);
        }

#pragma warning disable CS8618
        private Host() { }
#pragma warning restore CS8618
    }
}

