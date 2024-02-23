using System.Collections.Generic;
using BuberDinner.Domain.Common.Menu;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Menus.Commands.CreateMenu
{
    public record CreateMenuCommand : IRequest<ErrorOr<Menu>>
    {
        public string HostId { get; init; } = default!;
        public string Name { get; init; }= default!;
        public string Description { get; init; }= default!;
        public List<MenuSectionCommand> Sections { get; init; }= default!;

        public CreateMenuCommand() { }

        public CreateMenuCommand(string hostId, string name, string description, List<MenuSectionCommand> sections)
        {
            HostId = hostId;
            Name = name;
            Description = description;
            Sections = sections;
        }
    }

    public record MenuSectionCommand
    (
        string Name,
        string Description,
        List<MenuItemCommand> Items
    );

    public record MenuItemCommand
    (
        string Name,
        string Description
    );
}