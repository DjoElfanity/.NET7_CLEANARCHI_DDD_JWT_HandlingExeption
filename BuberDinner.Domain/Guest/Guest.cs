using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Guest.Entities;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Domain.Guest
{
    public class Guest : AggregateRoot<GuestId>
    {
        
        private readonly List<DinnerId> _pastDinnerIds = new();
        private readonly List<DinnerId> _pendingDinnerIds = new();
        private readonly List<DinnerId> _upcomingDinnerIds = new();
        private readonly List<BillId>  _billIds = new();

        private readonly List<MenuReviewId> _menuReviewIds = new();

        private readonly List<GuestRating> _ratings = new();

        


        
        public string FirstName {get;}
        public string LastName {get;}
        public string ProfileImage {get;}

        public float AverageRating{get;}

        public UserId UserId{get ; }

        public IReadOnlyList<DinnerId> UpComingDinnerIds => _upcomingDinnerIds.ToList();
        public IReadOnlyList<DinnerId> PendingDinnerIds => _pendingDinnerIds.ToList();
        public IReadOnlyList<DinnerId> PastDinnerIds => _pastDinnerIds.ToList();
        public IReadOnlyList<BillId> BillIds => _billIds.ToList();
        public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.ToList();
        public IReadOnlyList<GuestRating> Ratings => _ratings.ToList();




        public DateTime CreatedDateTime { get; }

        public DateTime UpdatedDateTime { get; }


        private Guest(
            GuestId guestId,
            string firstName,
            string lastName,
            string profileImage,
            float averageRating,
            UserId userId,
            DateTime createdDateTime
            ) : base(guestId)
        {
            FirstName = firstName;
            LastName = lastName;
            ProfileImage = profileImage;
            AverageRating = averageRating;
            UserId = userId;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = createdDateTime; // Initially, updatedDateTime is the same as createdDateTime
        }

         public static Guest Create(GuestId guestId, string firstName, string lastName, string profileImage, float averageRating, UserId userId)
        {
            var createdDateTime = DateTime.UtcNow;
            return new Guest(guestId, firstName, lastName, profileImage, averageRating, userId, createdDateTime);
        }



        
        

        

    }
}