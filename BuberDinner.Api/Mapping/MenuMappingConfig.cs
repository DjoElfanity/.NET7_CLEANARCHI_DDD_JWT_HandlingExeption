using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Application.Menus.Commands.CreateMenu;
using BuberDinner.Contracts.Menus;
using BuberDinner.Domain.Menu;
using Mapster;

using MenuSection = BuberDinner.Domain.Menu.Entities.MenuSection;
using MenuItem = BuberDinner.Domain.Menu.Entities.MenuItem;
using BuberDinner.Domain.Menu.ValueObjects;
using Microsoft.AspNetCore.SignalR;

namespace BuberDinner.Api.Mapping
{
    public class MenuMappingConfig : IRegister

    {
        public void Register(TypeAdapterConfig config)
        {
            // config.NewConfig<(CreateMenuRequest Request , string HostId) , CreateMenuCommand>()
            // .Map(dest => dest.HostId , src=> src.HostId)
            // .Map(dest => dest , src => src.Request);
            config.NewConfig<(CreateMenuRequest Request, string HostId), CreateMenuCommand>()
                .Map(dest => dest.HostId, src => src.HostId)
                .Map(dest => dest.Name, src => src.Request.Name)
                .Map(dest => dest.Description, src => src.Request.Description)
                .Map(dest => dest.Sections, src => src.Request.Sections.Select(s => new MenuSectionCommand(
                    s.Name, 
                    s.Descriptions, 
                    s.Items.Select(i => new MenuItemCommand(i.Name, i.Description)).ToList()
                )).ToList());


            config.NewConfig<Menu , MenuResponse>()
            .Map(dest => dest.Id , src => src.Id.Value)
            .Map(dest => dest.AverageRating , src => src.AverageRating)
            .Map(dest => dest.HostId , src => src.HostId.Value );
          //  .Map(dest => dest.MenuReviewsIds , src => src.MenuReviewIds.Select(menuId => menuId.Value) )
           // .Map(dest => dest.DinerIds , src => src.DinnerIds.Select(DinnerId => DinnerId.Value));

            config.NewConfig<MenuSection , MenuSectionResponse>()

            .Map(dest =>dest.Id , src => src.Id.Value);
            config.NewConfig<MenuItem , MenuItemResponse>()
            .Map(dest =>dest.Id , src => src.Id.Value);
        }

        
    }
}