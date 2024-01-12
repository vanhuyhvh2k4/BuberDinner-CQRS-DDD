﻿using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.MenuAggregate.Entities;
using BuberDinner.Domain.MenuAggregate.ValueObjects;
using BuberDinner.Domain.MenuReviewAggregate.ValueObjects;

namespace BuberDinner.Domain.MenuAggregate
{
    public sealed class Menu : AggregateRoot<MenuId>
    {
        private readonly List<MenuSection> _sections = new();

        private readonly List<DinnerId> _dinnerIds = new();

        private readonly List<MenuReviewId> _menuReviewIds = new();

        public string Name { get; }

        public string Description { get; }

        public AverageRating AverageRating { get; }

        public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();

        public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();

        public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();

        public HostId HostId { get; }

        public DateTime CreatedTime { get; }

        public DateTime UpdatedTime { get; }

        private Menu(
            MenuId menuId,
            string name,
            string description,
            HostId hostId,
            AverageRating averageRating,
            List<MenuSection>? sections,
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

        public static Menu Create(string name, string description, HostId hostId, List<MenuSection>? sections)
        {
            return new(
                MenuId.CreateUnique(),
                name,
                description,
                hostId,
                AverageRating.CreateNew(0),
                sections,
                DateTime.UtcNow,
                DateTime.UtcNow);
        }
    }
}

