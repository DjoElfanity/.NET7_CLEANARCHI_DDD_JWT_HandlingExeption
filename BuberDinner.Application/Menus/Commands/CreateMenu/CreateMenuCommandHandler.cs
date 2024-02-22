using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Menu;
using BuberDinner.Domain.Menu.Entities;
using BuberDinner.Domain.Menu.ValueObjects;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Menus.Commands.CreateMenu
{
    public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<Menu>>
    {
        private readonly IMenuRepository _menuRepository;

        public CreateMenuCommandHandler(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public async  Task<ErrorOr<Menu>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            //Create Menu 
            var menu = Menu.Create(
                hostId : HostId.Create(request.HostId),
                request.Name,
                request.Description,
                request.Sections.ConvertAll(section => MenuSection.Create(
                    section.Name,
                    section.Descriptions,
                    section.Items.ConvertAll(item =>MenuItem.Create(
                        item.Name,
                        item.Description
                        
                    )
                        
                    )

                ))


            );

            //Persistence Menu

            _menuRepository.Add(menu);




            //Return Menu 

            return menu; 
        }
    }
}