using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Application.Authentication.Common;
using ErrorOr;
using FluentResults;

namespace BuberDinner.Application.Services.Authentication
{
    public interface IAuthenticationCommandService
    {
        
        ErrorOr <AuthenticationResult> Register(
            string firstname , 
            string lastname , 
            string email , 
            string password
        );
    


    }
}