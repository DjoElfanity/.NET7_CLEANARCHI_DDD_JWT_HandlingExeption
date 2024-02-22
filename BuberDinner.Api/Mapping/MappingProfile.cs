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
using BuberDinner.Domain.Entities;
using BuberDinner.Domain.Menu;



namespace dotnet_test.Mapping
{
    public class MappingProfile : Profile
{
    public MappingProfile()
    {
            CreateMap<RegisterRequest, RegisterCommand>();
            CreateMap<LoginRequest, LoginQuery>();
            CreateMap<AuthenticationResult, AuthenticationResponse>();
            
            // Mappage pour la création de menu
            CreateMap<CreateMenuRequest, CreateMenuCommand>()
            .ConstructUsing(src => new CreateMenuCommand(
                    src.Name, 
                    src.Description, 
                    src.Sections.Select(s => new MenuSectionCommand(
                        s.Name, 
                        s.Descriptions, 
                        s.Items.Select(i => new MenuItemCommand(i.Name, i.Description)).ToList()
                    )).ToList(),
                    "" 
    ));
            
            // Mappages pour les entités et les réponses de menu
         CreateMap<Menu, MenuResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.Value)) // Conversion de Guid en string si nécessaire
            .ForMember(dest => dest.AverageRating, opt => opt.MapFrom(src => src.AverageRating))
            .ForMember(dest => dest.HostId, opt => opt.MapFrom(src => src.HostId.Value)) // Conversion de Guid en string si nécessaire
            .ForMember(dest => dest.MenuReviewsIds, opt => opt.MapFrom(src => src.MenuReviewIds.Select(id => id.ToString()).ToList())) // Conversion de chaque Guid en string
            .ForMember(dest => dest.DinerIds, opt => opt.MapFrom(src => src.DinnerIds.Select(id => id.ToString()).ToList()))
             ;// Conversion de chaque Guid en string

            // Mappage de MenuSection à MenuSectionResponse
            CreateMap<MenuSection, MenuSectionCommand>()
                 .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));


            CreateMap<MenuSection, MenuSectionResponse>()
            ;
             // S'assurer que les items sont également mappés

        CreateMap<MenuItem, MenuItemResponse>()
            
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));
            

            // Mappage de MenuItem à MenuItemResponse
            CreateMap<MenuItem, MenuItemCommand>();
        }

        
           
           

      

        
       
        

    }
}
