using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuberDinner.Domain.Entities
{
    public class User
    {
        
        public Guid Id { get; set; }  = Guid.NewGuid();
        public string FirstName {get ; set;}   = null!; 
        public string Lastname {get ; set;}   = null!; 
        public string Email {get ; set;}  = null!; 
        public string Password {get ; set;}  = null!; 
        





    }
}