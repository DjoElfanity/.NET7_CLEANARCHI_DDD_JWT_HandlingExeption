using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Menu.Entities;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Domain.Menu
{
    public sealed class Menu : AggregateRoot<MenuId>
    {
        private readonly List<MenuSection> _sections = new();
        private readonly List<DinnerId> _dinnerIds = new(); 

        private readonly List<MenuReviewId> _menuReviewIds = new();


        public string Name {get; }
        public string Description {get; }
        public float AverageRating  {get; }



        IReadOnlyList<MenuItem> Sections => (IReadOnlyList<MenuItem>)_sections.ToList();
        IReadOnlyList<MenuItem> DinnerIds => (IReadOnlyList<MenuItem>)_dinnerIds.ToList();
        IReadOnlyList<MenuItem> MenuReviewIds => (IReadOnlyList<MenuItem>)_menuReviewIds.ToList();

        public DateTime CreatedDateTime {get;}
        public DateTime UpdatedDateTime {get;}
        public HostId HostId {get;}
        private Menu(
        MenuId menuId , 
        string name , 
        string description, 
        HostId hostId, 
        DateTime createdDateTime ,
        DateTime updatedDateTime 
        ) : base(menuId)
        {
        Name = name ;
        Description = description ; 
        HostId = hostId;
        CreatedDateTime = createdDateTime ;
        UpdatedDateTime = updatedDateTime ;  

        }


         public static Menu Create(
            string name, 
            string description , 
            HostId hostId
        )
        {
            return new(
            MenuId.CreateUnique(),
            name,
            description,
            hostId,
            DateTime.UtcNow,
            DateTime.UtcNow
        );
        }
        

     
        
    }
   
}