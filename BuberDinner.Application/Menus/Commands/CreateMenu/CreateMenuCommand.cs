using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Domain.Menu;
using BuberDinner.Domain.Menu.Entities;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Menus.Commands.CreateMenu
{
    public record CreateMenuCommand(

      string Name ,
      string Description , 
      
      List<MenuSectionCommand> Sections,
      string HostId       



    )  :IRequest<ErrorOr<Menu>>;

        public record MenuSectionCommand(
        string Name, 
        string Descriptions,
        List<MenuItemCommand> Items
    );

    public record MenuItemCommand(
        string Name,
        string Description
    );
    
}