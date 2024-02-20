using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Menu.ValueObjects
{
    public sealed class GuestRatingId : ValueObject
    {
        public Guid Value {get; }

        private GuestRatingId(Guid value) {
            Value = value; 

        }

        public static GuestRatingId CreateUnique()
        {
            return new (Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value ; 
        }
    }
}