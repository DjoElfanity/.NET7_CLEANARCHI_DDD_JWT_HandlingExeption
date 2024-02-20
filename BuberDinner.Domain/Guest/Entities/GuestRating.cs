using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Domain.Guest.Entities
{
    public class GuestRating: Entity<GuestRatingId>
    {
    public HostId HostId { get; set; }
    public DinnerId DinnerId { get; set; }
    public int RatingValue { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public DateTime UpdatedDateTime { get; set; }


    public GuestRating(GuestRatingId guestRatingId,HostId hostId, DinnerId dinnerId, int ratingValue, DateTime createdDateTime, DateTime updatedDateTime)
    :base(guestRatingId)
        {
            HostId = hostId;
            DinnerId = dinnerId;
            RatingValue = ratingValue;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }
    }
}