using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Application.Common.Errors;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
// using BuberDinner.Application.Services.Authentication;
using BuberDinner.Domain.Entities;
using ErrorOr;
using MediatR;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Application.Authentication.Common;


namespace BuberDinner.Application.Authentication.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr <AuthenticationResult>>
    {
         private readonly IJwtTokenGenerator _jwtTokenGenerator ;

        private readonly IUserRepository _userRepository;

        public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator,IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator; 
            _userRepository = userRepository;
        }

        public async Task<ErrorOr <AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {

             if (_userRepository.GetUserByEmail(command.Email) is not null)
            {
                return Errors.User.DuplicateEmail; 
            }
            // var user = User.
            // {
                
            //     FirstName = command.FirstName, 
            //     Lastname = command.LastName ,
            //     Email = command.Email , 
            //     Password = command.Password 
            // };

            var user = User.Create(
                command.FirstName,
                command.LastName,
                command.Email,
                command.Password
);


            _userRepository.Add(user);
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
               user, token);
            
        }
    }
}