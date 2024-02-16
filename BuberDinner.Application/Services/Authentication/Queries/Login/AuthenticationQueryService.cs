using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Common.Errors;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.Entities;
using ErrorOr;

namespace BuberDinner.Application.Services.Authentication
{
    public class AuthenticationQueryService : IAuthenticationQueryService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator ;

        private readonly IUserRepository _userRepository; 

        public AuthenticationQueryService(IJwtTokenGenerator jwtTokenGenerator , IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository ; 
        }

    
        public ErrorOr <AuthenticationResult> Login(string email, string password)
        {
            //1 chercher si le user existe 
            if (_userRepository.GetUserByEmail(email) is not User user)
                    return Errors.Authentication.InvalidCredentials; 

            if (user.Password != password)
                    return Errors.Authentication.InvalidCredentials; 

            
            var token = _jwtTokenGenerator.GenerateToken(user);
            return new AuthenticationResult(
               user ,
                token);

        }
    }
} 