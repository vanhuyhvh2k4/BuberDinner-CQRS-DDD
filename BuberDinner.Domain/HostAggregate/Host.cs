using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.UserAggregate.ValueObjects;

namespace BuberDinner.Domain.HostAggregate
{
    public class Host : AggregateRoot<HostId>
    {
        public string FirstName { get; }

        public string LastName { get; }

        public string ProfileImage { get; }

        public AverageRating AverageRating { get; }

        public UserId UserId { get; }

        public DateTime CreatedDateTime { get; }

        public DateTime UpdatedDateTime { get; }

        private Host(
            HostId hostId,
            string firstName,
            string lastName,
            string profileImage,
            AverageRating averageRating,
            UserId userId,
            DateTime createdDateTime,
            DateTime updateDateTime) : base(hostId)
        {
            FirstName = firstName;
            LastName = lastName;
            ProfileImage = profileImage;
            AverageRating = averageRating;
            UserId = userId;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updateDateTime;
        }

        public static Host Create(
            string firstName,
            string lastName,
            string profileImage,
            AverageRating averageRating,
            UserId userId
            )
        {
            return new(
                HostId.CreateUnique(),
                firstName,
                lastName,
                profileImage,
                averageRating,
                userId,
                DateTime.UtcNow,
                DateTime.UtcNow);
        }
    }
}

