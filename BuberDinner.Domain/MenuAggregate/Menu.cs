using System;
using System.Collections.Generic;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Menu.Entities;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Domain.Menu
{
    public sealed class Menu : AggregateRoot<MenuId>
    {
        private readonly List<MenuSection> _sections = new();
        private readonly List<DinnerId> _dinnerIds = new(); // Assurez-vous d'avoir cette liste
        private readonly List<MenuReviewId> _menuReviewIds = new();

        public string Name { get; }
        public string Description { get; }
        // Supposé que AverageRating sera calculé ou mis à jour séparément
        public float AverageRating { get; private set; }

        public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();
        public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
        public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();
        // Les propriétés DinnerIds et MenuReviewIds sont retirées pour simplifier l'exemple
        public DateTime CreatedDateTime { get; private set; }
        public DateTime UpdatedDateTime { get; private set; }
        public HostId HostId { get; }

        private Menu(
            MenuId menuId,
            string name,
            string description,
            HostId hostId,
            // List<MenuSection> sections,
            DateTime createdDateTime,
            DateTime updatedDateTime
        ) : base(menuId)
        {
            Name = name;
            Description = description;
            HostId = hostId;
            // _sections = sections ?? new List<MenuSection>();
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static Menu Create(
            HostId hostId,
            string name,
            string description,
            List<MenuSection> sections
        )
        {
            // Assurez-vous que les sections ne sont pas nulles avant de les passer
            sections = sections ?? new List<MenuSection>();
            return new Menu(
                MenuId.CreateUnique(),
                name,
                description,
                hostId,
                // sections,
                DateTime.UtcNow, // Utilisez DateTime.UtcNow pour initialiser les dates de création et de mise à jour
                DateTime.UtcNow
            );
        }
    }
}
