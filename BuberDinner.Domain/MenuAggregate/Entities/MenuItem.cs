using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Domain.Menu.Entities
{
    public sealed class MenuItem : Entity<MenuItemId>
    {
        private MenuItem(MenuItemId menuItemId , string name , string description  , double price) : base(menuItemId)
        {
            Name = name ;
            Description = description; 
            Price= price ; 
        }

        public string Name { get;  }
        public string Description { get;  }

        public double Price { get; }

        


    }
}