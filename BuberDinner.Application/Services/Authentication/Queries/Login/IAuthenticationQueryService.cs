using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Application.Authentication.Common;
using ErrorOr;
using FluentResults;

namespace BuberDinner.Application.Services.Authentication
{
    public interface IAuthenticationQueryService
    {
        
      
        ErrorOr <AuthenticationResult> Login(
            string email , 
            string password
        );
        


    }
}