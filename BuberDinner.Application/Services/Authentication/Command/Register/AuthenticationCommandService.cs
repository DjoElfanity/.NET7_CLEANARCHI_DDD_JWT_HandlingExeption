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
    public class AuthenticationCommandService : IAuthenticationCommandService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator ;

        private readonly IUserRepository _userRepository; 

        public AuthenticationCommandService(IJwtTokenGenerator jwtTokenGenerator , IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository ; 
        }

        public ErrorOr <AuthenticationResult> Register(string firstname, string lastname, string email, string password)
        {
            
            // Valider que le user n'existe pas :
            if (_userRepository.GetUserByEmail(email) is not null)
            {
                return Errors.User.DuplicateEmail; 
            }
            var user = new User
            {
                FirstName = firstname, 
                Lastname = lastname ,
                Email = email , 
                Password = password 
            };

            _userRepository.Add(user);
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
               user, token);
        }

        
    }
} 