using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BuberDinner.Application.Authentication.Commands;
using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Menus.Commands.CreateMenu;
using BuberDinner.Contracts.Authentication;
using BuberDinner.Contracts.Menus;
using BuberDinner.Domain.Common.Menu;
using BuberDinner.Domain.Entities;
using BuberDinner.Domain.Menu;

using MenuSection = BuberDinner.Domain.Menu.Entities.MenuSection;
using MenuItem = BuberDinner.Domain.Menu.Entities.MenuItem;



/*
CreateMap<Menu, MenuResponse>()
    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.Value))
    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
    .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
    .ForMember(dest => dest.AverageRating, opt => opt.MapFrom(src => src.AverageRating))
    .ForMember(dest => dest.HostId, opt => opt.MapFrom(src => src.HostId.Value))
    .ForMember(dest => dest.Sections, opt => opt.MapFrom(src => src.Sections.Select(s => new MenuSectionResponse(
        s.Id.Value.ToString(), // Access the value of MenuSectionId
        s.Name,
        s.Description,
        s.Items.Select(i => new MenuItemResponse(
            i.Id.Value.ToString(), // Access the value of MenuItemId
            i.Name,
            i.Description
        )).ToList()
    )).ToList()));

*/

namespace dotnet_test.Mapping
{
    public class MappingProfile : Profile
{
    public MappingProfile()
    {
            CreateMap<RegisterRequest, RegisterCommand>();
            CreateMap<LoginRequest, LoginQuery>();
            CreateMap<AuthenticationResult, AuthenticationResponse>();


            CreateMap<(CreateMenuRequest Request, string HostId), CreateMenuCommand>()
                    .ForMember(dest => dest.HostId, opt => opt.MapFrom(src => src.HostId))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Request.Name))
                    .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Request.Description))
                    .ForMember(dest => dest.Sections, opt => opt.MapFrom(src => 
                        src.Request.Sections.Select(s =>
                            new MenuSectionCommand(
                                s.Name, 
                                s.Descriptions, 
                                s.Items.Select(i => new MenuItemCommand(i.Name, i.Description)).ToList()
                            )
                        ).ToList()
                    ));

   

           CreateMap<Menu, MenuResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.Value))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.AverageRating, opt => opt.MapFrom(src => src.AverageRating))
                .ForMember(dest => dest.HostId, opt => opt.MapFrom(src => src.HostId.Value))
                .ForMember(dest => dest.Sections, opt => opt.MapFrom(src => src.Sections.Select(s => new MenuSectionResponse(
                    s.Id.Value.ToString(), // Access the value of MenuSectionId
                    s.Name,
                    s.Description,
                    s.Items.Select(i => new MenuItemResponse(
                        i.Id.Value.ToString(), // Access the value of MenuItemId
                        i.Name,
                        i.Description
                    )).ToList()
                )).ToList()));
                

            
   

            CreateMap<MenuSection, MenuSectionResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.Value))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items.Select(i => new MenuItemResponse(
                    i.Id.Value.ToString(),
                    i.Name,
                    i.Description
                )).ToList()))
                
                ;

            CreateMap<MenuItem, MenuItemResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.Value))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))


                
                ;
                CreateMap<CreateMenuCommand, MenuItem>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                
                ;
               
                
           
        }

        
           
           

      

        
       
        

    }
}
