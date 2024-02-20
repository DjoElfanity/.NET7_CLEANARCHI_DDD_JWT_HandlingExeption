using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Domain.MenuReview
{
    public class MenuReview : AggregateRoot<MenuReviewId>
    {
        
    public int Rating {get;}
    public string Comment {get;}

    public HostId HostId {get;}
    public MenuId MenuId {get;}
    public GuestId GuestId {get;}
    public DinnerId DinnerId {get;}

     public DateTime CreatedDateTime{get;}
    public DateTime UpdatedDateTime{get;}


    private MenuReview(
        MenuReviewId menuReviewId,
        int rating , 
        string comment, 
        HostId hostId, 
        MenuId menuId,
        GuestId guestId,
        DinnerId dinnerId,
        DateTime createdDateTime,
        DateTime updatedDateTime


    ) : base(menuReviewId)
    {
        Rating = rating;
            Comment = comment;
            HostId = hostId;
            MenuId = menuId;
            GuestId = guestId;
            DinnerId = dinnerId;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;

    }

    public static MenuReview Create(
            MenuReviewId menuReviewId,
            int rating,
            string comment,
            HostId hostId,
            MenuId menuId,
            GuestId guestId,
            DinnerId dinnerId
        )
        {
            var createdDateTime = DateTime.UtcNow;
            // Assuming the updatedDateTime is the same as createdDateTime initially
            return new MenuReview(
                menuReviewId,
                rating,
                comment,
                hostId,
                menuId,
                guestId,
                dinnerId,
                createdDateTime,
                createdDateTime
            );
        }
    
    






    }
}