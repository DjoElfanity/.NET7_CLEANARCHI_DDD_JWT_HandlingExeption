using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Application.Authentication.Commands;
using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Services.Authentication;
using BuberDinner.Contracts.Authentication;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers
{
   
    [Route("auth")]
    public class AuthenticationController : ApiController
    {
        // private readonly IAuthenticationCommandService _authenticationComamndService;
        // private readonly IAuthenticationQueryService _authenticationQueryService;

        private readonly IMediator _mediator ;

        public AuthenticationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // public AuthenticationController(IAuthenticationCommandService authenticationCommandService , IAuthenticationQueryService authenticationQueryService)
        // {
        //     _authenticationComamndService = authenticationCommandService;
        //     _authenticationQueryService  = authenticationQueryService ; 
        // }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var command = new RegisterCommand(request.FirstName , request.LastName , request.Email , request.Password);
            ErrorOr<AuthenticationResult> authResult =  await  _mediator.Send(command);
      
            return authResult.Match(
                    authResult => Ok(MapAuthResult(authResult)),
                    errors=> Problem(errors)
            );    

        }

       
        [HttpPost("login")]
        public async Task <IActionResult> Login(LoginRequest request)
        {
            var query = new LoginQuery(request.Email , request.Password);
            ErrorOr<AuthenticationResult> authResult = await _mediator.Send(query);
            

           return authResult.Match(
               authResult => Ok(MapAuthResult(authResult)),
                errors => Problem(errors)     
           );

           
        }

         public static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
            {
                return new AuthenticationResponse(
                                authResult.User.Id,
                                authResult.User.FirstName,
                                authResult.User.Lastname,
                                authResult.User.Email,
                                authResult.Token
                            );
            }





    }
}