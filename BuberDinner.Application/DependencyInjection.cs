using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using BuberDinner.Application.Authentication.Commands;
using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Common.Behavior;
using BuberDinner.Application.Menus.Commands.CreateMenu;
using BuberDinner.Application.Services.Authentication;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

using Mapster;
using MapsterMapper;

namespace BuberDinner.Application
{
    public static class DependencyInjection
    {
            public static IServiceCollection AddApplication(this IServiceCollection services)
{
                // Configuration existante
                services.AddMediatR(typeof(DependencyInjection).Assembly);
                services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidateRegisterCommandBehavior<,>));
                services.AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });

                // Configuration Mapster
                var config = new TypeAdapterConfig();
                // Ajoutez vos configurations de mappage ici, par exemple :
                // config.NewConfig<SourceType, DestinationType>();
                
                services.AddSingleton(config);
                services.AddScoped<IMapper, ServiceMapper>(); // Enregistre le ServiceMapper de Mapster comme l'implémentation de IMapper
                services.AddTransient<IValidator<CreateMenuCommand>, CreateMenuCommandValidator>();


                return services;
}


//             public static IServiceCollection AddApplication(this IServiceCollection services)
// {
//                     services.AddMediatR(typeof(DependencyInjection).Assembly);

//                     // Ajout du validateur spécifique pour CreateMenuCommand
//                     services.AddScoped<IValidator<CreateMenuCommand>, CreateMenuCommandValidator>();

//                     services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidateRegisterCommandBehavior<,>));

//                     // Cette ligne ajoute automatiquement tous les validateurs trouvés dans l'assemblage
//                     services.AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });

//                     return services;
// }

    }
}