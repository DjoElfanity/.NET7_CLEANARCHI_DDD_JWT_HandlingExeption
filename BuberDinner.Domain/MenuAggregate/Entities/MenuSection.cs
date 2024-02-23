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

        
        public MenuSection(MenuSectionId menuSectionId, string name, string description, List<MenuItem> items) 
            : base(menuSectionId)
        {

            Name = name;
            Description = description;
            _items = items ?? new List<MenuItem>(); // Initialise _items avec la liste fournie ou une nouvelle liste si null
        }
        private  readonly List<MenuItem> _items = new();
        
        public string Name { get; }
        public string Description { get; }

        public  IReadOnlyList<MenuItem> Items => _items.ToList();

         public static MenuSection Create(
            string name,
            string description,
            List<MenuItem> items // Ajouter des items comme paramètre
        )
        {
            return new MenuSection(
                MenuSectionId.CreateUnique(),
                name,
                description,
                items // Passer les items au constructeur
            );
        }
    



    }
}