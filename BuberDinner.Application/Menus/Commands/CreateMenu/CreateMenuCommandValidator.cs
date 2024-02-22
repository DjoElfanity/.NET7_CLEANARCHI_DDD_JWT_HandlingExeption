using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace BuberDinner.Application.Menus.Commands.CreateMenu
{
    public class CreateMenuCommandValidator : AbstractValidator<CreateMenuCommand>
{
    public CreateMenuCommandValidator()
    {
        RuleFor(command => command.Name).NotEmpty();
        RuleFor(command => command.Description).NotEmpty();
        RuleFor(command => command.Sections).NotEmpty();
        RuleFor(command => command.HostId).NotEmpty();
        RuleFor(command => command.HostId)
            .NotEmpty()
            .Must(hostId => Guid.TryParse(hostId, out _))
            .WithMessage("HostId must be a valid GUID.");

    }
}

}