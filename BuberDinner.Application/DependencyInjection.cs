using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using BuberDinner.Application.Authentication.Commands;
using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Common.Behavior;
using BuberDinner.Application.Services.Authentication;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BuberDinner.Application
{
    public static class DependencyInjection
    {
            public static  IServiceCollection AddApplication( this IServiceCollection services)
            {
            // services.AddScoped<IAuthenticationCommandService , AuthenticationCommandService>(); 
            // services.AddScoped<IAuthenticationQueryService , AuthenticationQueryService>(); 
            services.AddMediatR(typeof(DependencyInjection).Assembly);
            services.AddScoped(
            typeof(IPipelineBehavior<,>),
            typeof(ValidateRegisterCommandBehavior<,>)

            );
            // services.AddScoped<IPipelineBehavior<RegisterCommand , ErrorOr<AuthenticationResult>> , ValidateRegisterCommandBehavior>();
            services.AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });

            
            return services; 

            }
    }
}