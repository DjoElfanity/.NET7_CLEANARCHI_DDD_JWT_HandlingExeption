using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Application.Authentication.Common;
// using BuberDinner.Application.Services.Authentication;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Authentication.Commands
{
    public record RegisterCommand
    (
            string FirstName , 
            string LastName ,

            string Email , 
            string Password  
    ): IRequest<ErrorOr <AuthenticationResult>> ;
}