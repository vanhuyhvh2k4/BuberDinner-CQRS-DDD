﻿using System;
using BuberDinner.Domain.Bill.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.Entities;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Domain.Dinner
{
    public class Dinner : AggregateRoot<DinnerId>
    {
        private readonly List<Reservation> _reservations = new();

        public string Name { get; }

        public string Description { get; }

        public DateTime StartDateTime { get; }

        public DateTime EndDateTime { get; }

        public DateTime? StartedDateTime { get; private set; }

        public DateTime? EndedDateTime { get; private set; }

        public string Status { get; }

        public bool IsPublic { get; }

        public int MaxGuest { get; }

        public Price Price { get; }

        public HostId HostId { get; }

        public MenuId MenuId { get; }

        public string ImageUrl { get; }

        public Location Location { get; }

        public IReadOnlyList<Reservation> Reservations => _reservations.AsReadOnly();

        public DateTime CreatedDateTime { get; }

        public DateTime UpdatedDateTime { get; }

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
    }
}

