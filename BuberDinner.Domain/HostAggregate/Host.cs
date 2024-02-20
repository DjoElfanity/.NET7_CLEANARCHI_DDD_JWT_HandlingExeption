using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Domain.Host
{
    public class Host: AggregateRoot<HostId>
    {

        // private readonly UserId _userId; 
        private readonly List<MenuId> _menuIds = new ();
        private readonly List<DinnerId> _dinnerIds = new ();
        public string FirstName {get ; set;}   = null!; 
        public string Lastname {get ; set;}   = null!; 
            
        public string ProfileImage{get;}

        public UserId UserId {get;}

        public IReadOnlyList<MenuId> MenuId => _menuIds.ToList() ; 
        public IReadOnlyList<DinnerId> DinnerId => _dinnerIds.ToList() ; 

        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }
        public float AverageRating{get;}


        private Host(
        HostId hostId ,
        UserId userId, 
        string firstname,
        string lastname , 
        string profileImage , 
        DateTime createdDateTime,
        DateTime updatedDateTime


        ) : base(hostId)

        {
            FirstName = firstname;
            Lastname = lastname ;
            UserId = userId; 
            ProfileImage = profileImage ;
            AverageRating = 0;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
           
             
        }

        public static Host Create
        (
        string firstname,
        string lastname , 
        string profileImage  ,
        UserId userId  

        )
        {
            return new Host(
                HostId.CreateUnique(),
                userId,
                firstname,
                lastname , 
                profileImage ,
                DateTime.UtcNow,
                DateTime.UtcNow
            );
        }

        






        
    }
}