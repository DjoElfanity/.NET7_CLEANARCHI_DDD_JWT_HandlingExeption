using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Menu.ValueObjects
{
    public sealed class HostId : ValueObject
    {
        public Guid Value {get; }

        private HostId(Guid value) {
            Value = value; 

        }

         public static HostId Create(string value)
        {
            // Assurez-vous que la valeur peut être convertie en Guid
            if (!Guid.TryParse(value, out Guid guidValue))
            {
                throw new ArgumentException("Invalid GUID string passed to HostId.Create");
            }
            return new HostId(guidValue);
        }

        public static HostId CreateUnique()
        {
            return new (Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value ; 
        }
    }
}