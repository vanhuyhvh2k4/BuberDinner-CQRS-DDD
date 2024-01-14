using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.MenuAggregate.Entities;
using BuberDinner.Domain.MenuAggregate.Events;
using BuberDinner.Domain.MenuAggregate.ValueObjects;
using BuberDinner.Domain.MenuReviewAggregate.ValueObjects;

namespace BuberDinner.Domain.MenuAggregate
{
    public sealed class Menu : AggregateRoot<MenuId>
    {
        private readonly List<MenuSection> _sections = new();

        private readonly List<DinnerId> _dinnerIds = new();

        private readonly List<MenuReviewId> _menuReviewIds = new();

        public string Name { get; private set; }

        public string Description { get; private set; }

        public AverageRating AverageRating { get; private set; }

        public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();

        public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();

        public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();

        public HostId HostId { get; private set; }

        public DateTime CreatedTime { get; private set; }

        public DateTime UpdatedTime { get; private set; }

        private Menu(
            MenuId menuId,
            string name,
            string description,
            HostId hostId,
            AverageRating averageRating,
            List<MenuSection> sections,
            DateTime createdTime,
            DateTime updatedTime) : base(menuId)
        {
            Name = name;
            Description = description;
            HostId = hostId;
            AverageRating = averageRating;
            _sections = sections;
            CreatedTime = createdTime;
            UpdatedTime = updatedTime;
        }

        public static Menu Create(string name, string description, HostId hostId, List<MenuSection> sections)
        {
            var menu = new Menu(
                MenuId.CreateUnique(),
                name,
                description,
                hostId,
                AverageRating.CreateNew(0),
                sections,
                DateTime.UtcNow,
                DateTime.UtcNow);

            menu.AddDomainEvent(new MenuCreated(menu));

            return menu;
        }
#pragma warning disable CS8618
        private Menu() {}
#pragma warning restore CS8618
    }
}

