using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Application.Services.Authentication;
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
            
            return services; 

            }
    }
}