using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuberDinner.Contracts.Menus
{
    // Modifier le record en classe si vous avez besoin d'un constructeur sans paramètres.
    public class MenuResponse
    {
        public string Id { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public float? AverageRating { get; init; }
        public List<MenuSectionResponse> Sections { get; init; }
        public string HostId { get; init; }
        public List<string> DinerIds { get; init; }
        public List<string> MenuReviewsIds { get; init; }
        public DateTime CreatedDateTime { get; init; }
        public DateTime UpdatedDateTime { get; init; }

        // Constructeur sans paramètres pour permettre l'initialisation sans fournir de valeurs.
        public MenuResponse() : this(string.Empty, string.Empty, string.Empty, null, new List<MenuSectionResponse>(), string.Empty, new List<string>(), new List<string>(), DateTime.MinValue, DateTime.MinValue)
        {
        }

        // Constructeur principal qui accepte toutes les valeurs.
        public MenuResponse(string id, string name, string description, float? averageRating, List<MenuSectionResponse> sections, string hostId, List<string> dinerIds, List<string> menuReviewsIds, DateTime createdDateTime, DateTime updatedDateTime)
        {
            Id = id;
            Name = name;
            Description = description;
            AverageRating = averageRating;
            Sections = sections ?? new List<MenuSectionResponse>();
            HostId = hostId;
            DinerIds = dinerIds ?? new List<string>();
            MenuReviewsIds = menuReviewsIds ?? new List<string>();
            
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }
    }

    public record MenuSectionResponse(
            string Id,
            string Name,
            string Description,
            List<MenuItemResponse> Items
    );

    public record MenuItemResponse(
            string Id,
            string Name,
            string Description
    );
}
