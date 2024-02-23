using System;
using System.Collections.Generic;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Menu.Entities;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Domain.Common.Menu
{
    public sealed class Menu : AggregateRoot<MenuId>
    {
        private readonly List<MenuSection> _sections = new();
        private readonly List<DinnerId> _dinners = new();
        private readonly List<MenuReviewId> _menuReviews = new();
        public string Name { get; }
        public string Description { get; }
        public float AverageRating { get; }
        public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();
        public HostId HostId { get; } 
        public IReadOnlyList<DinnerId> Dinners => _dinners.AsReadOnly();
        public IReadOnlyList<MenuReviewId> MenuReviews => _menuReviews.AsReadOnly();
        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }    
         private Menu(MenuId menuId,HostId hostId, string name, string description, List<MenuSection> sections ,DateTime createdDateTime, DateTime updatedDateTime) : base(menuId)
        {
            HostId = hostId;
            Name = name;
            Description = description;
            _sections = sections;
            AverageRating = 0;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }
        public static Menu Create( HostId hostId,string name, string description , List<MenuSection> sections)
        {
            return new(MenuId.CreateUnique(), hostId, name , description, sections  ,DateTime.UtcNow, DateTime.UtcNow);
        }   
    }
}