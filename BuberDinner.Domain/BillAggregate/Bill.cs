using System;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Domain.Bill
{
    public sealed class Bill : AggregateRoot<BillId>
    {
        private readonly DinnerId _dinnerId;
        private readonly HostId _hostId;
        private readonly GuestId _guestId; // Ajout d'un commentaire pour clarifier l'intention

        private readonly Price _price;

        // Utilisation de la convention de nommage cohérente pour les propriétés
        public DinnerId DinnerId => _dinnerId;
        public HostId HostId => _hostId;
        public GuestId GuestId => _guestId;
        public Price Price => _price;
        public DateTime CreatedDateTime { get; private set; }
        public DateTime UpdatedDateTime { get; private set; }

        // Utilisation de commentaires pour expliquer la fonction du constructeur
        private Bill(
            BillId billId,
            DinnerId dinnerId,
            GuestId guestId,
            HostId hostId,
            Price price,
            DateTime createdDateTime,
            DateTime updatedDateTime
        ) : base(billId)
        {
            _dinnerId = dinnerId;
            _guestId = guestId; 
            _hostId = hostId;
            _price = price;

            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        // Utilisation de commentaires pour expliquer la fonction de la méthode de création
        public static Bill Create(
            DinnerId dinnerId,
            HostId hostId,
            GuestId guestId,
            Price price
        )
        {
            return new Bill(
                BillId.CreateUnique(),
                dinnerId,
                guestId,
                hostId,
                price,
                DateTime.UtcNow,
                DateTime.UtcNow
            );
        }
    }
}
