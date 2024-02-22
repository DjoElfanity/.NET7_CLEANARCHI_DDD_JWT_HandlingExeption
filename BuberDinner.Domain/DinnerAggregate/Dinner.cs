using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Domain.Common.Enums;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Menu.Entities;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Domain.Dinner
{
    public class Dinner : AggregateRoot<DinnerId>
    {
        private readonly List<DinnerReservation> _reservations = new();

        public IReadOnlyList<DinnerReservation> Reservations => _reservations.AsReadOnly();

        public string Name { get; }
        public string Description { get; }
        public DateTime StartDateTime { get; }
        public DateTime EndDateTime { get; }
        public DateTime? StartedDateTime { get; }
        public DateTime? EndedDateTime { get; }
        public Status Status { get; } = Status.Upcoming;
        public bool IsPublic { get; } = true;
        public int MaxGuests { get; }
        public Price Price { get; }
        public MenuId MenuId { get; }
        public HostId HostId { get; }
        public string ImageUrl { get; }
        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }

        

        public static Dinner Create(
            string name,
            string description,
            DateTime startDateTime,
            DateTime endDateTime,
            int maxGuests,
            MenuId menuId,
            HostId hostId,
            Price price,
            string imageUrl
        )
        {
            return new Dinner(
                DinnerId.CreateUnique(),
                name,
                description,
                startDateTime,
                endDateTime,
                maxGuests,
                menuId,
                hostId,
                price,
                imageUrl,
                DateTime.UtcNow,
                DateTime.UtcNow
            );
        }

        private Dinner(
            DinnerId id,
            string name,
            string description,
            DateTime startDateTime,
            DateTime endDateTime,
            int maxGuests,
            MenuId menuId,
            HostId hostId,
            Price price,
            string imageUrl,
            DateTime createdDateTime,
            DateTime updatedDateTime
        ) : base(id)
        {
            Name = name;
            Description = description;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            MaxGuests = maxGuests;
            MenuId = menuId;
            HostId = hostId;
            Price = price;
            ImageUrl = imageUrl;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }
    }
}
