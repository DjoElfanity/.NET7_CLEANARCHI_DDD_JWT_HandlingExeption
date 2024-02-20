using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Menu.ValueObjects
{
    public sealed class DinnerReservationId : ValueObject
    {
        public Guid Value {get; }

        private DinnerReservationId(Guid value) {
            Value = value; 

        }

        public static DinnerReservationId CreateUnique()
        {
            return new (Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value ; 
        }
    }
}