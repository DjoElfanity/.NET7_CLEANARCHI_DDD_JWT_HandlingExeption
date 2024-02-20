using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Domain.Menu.Entities
{
    public sealed class MenuSection : Entity<MenuSectionId>
    {
        public MenuSection(MenuSectionId menuSectionId , string name , string description) : base(menuSectionId)
        {
            Name =  name ;
            Description  = description ; 
        }
        private readonly List<MenuItem> _items = new();
        public string Name { get; }
        public string Description { get; }

        IReadOnlyList<MenuItem> Items => _items.ToList();

        public static MenuSection Create(
            string name ,
            string description 
        )
        {
            return new(
                MenuSectionId.CreateUnique(),
                name, 
                description
            
            );

        }



    }
}