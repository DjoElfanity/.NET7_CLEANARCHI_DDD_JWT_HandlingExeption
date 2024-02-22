using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Domain.Common.Enums;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.Enum;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Domain.Menu.Entities
{
    public sealed class DinnerReservation : Entity<DinnerReservationId>
    {

        readonly GuestId _guestId;
        readonly BillId _billId;

                public DinnerReservation(
            DinnerReservationId DinnerReservationId,
            GuestId guestId,
            BillId billId,
            int guestCount,
            DateTime arrivalDateTime,
            DateTime createdDateTime,
            DateTime updatedDateTime
        ) : base(DinnerReservationId)
        {
            _guestId = guestId;
            _billId = billId;
            GuestCount = guestCount;
            ArrivalDateTime = arrivalDateTime;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }


        public int GuestCount {get ;}
        public ReservationStatus ReservationStatus {get ;} = ReservationStatus.PendingGuestConfirmation;

        public BillId BillId => _billId ; 
        public GuestId GuestId => _guestId ; 

        public DateTime ArrivalDateTime {get;}

        public DateTime CreatedDateTime {get;}
        public DateTime UpdatedDateTime {get;}

        


        
        



    }
}