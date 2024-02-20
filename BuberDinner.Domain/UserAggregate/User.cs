using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Domain.Entities
{
    public class User: AggregateRoot<UserId>
    {
        

        //public Guid Id { get; set; }  = Guid.NewGuid();
        public string FirstName {get ; set;}   = null!; 
        public string Lastname {get ; set;}   = null!; 
        public string Email {get ; set;}  = null!; 
        public string Password {get ; set;}  = null!; 

        public DateTime CreatedDateTime{get;}
        public DateTime UpdatedDateTime{get;}

   
        private User(
            UserId UserId,
            string firstname ,
            string lastname,
            string email , 
            string password,
            DateTime createdDateTime ,
            DateTime updatedDateTime
            
            ) : base(UserId)
        {
            
            FirstName = firstname ;
            Lastname = lastname; 
            Email = email; 
            Password = password ;  
            CreatedDateTime = createdDateTime; 
            UpdatedDateTime = updatedDateTime;  

        }

        public static User Create(

            string firstname ,
            string lastname,
            string email , 
            string password
        )
        {
            return new(
                UserId.CreateUnique(),
                firstname,
                lastname,
                email,
                password,
                DateTime.UtcNow,
                DateTime.UtcNow

            );
        }
        


        





    }
}