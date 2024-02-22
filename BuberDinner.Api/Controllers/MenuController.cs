using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BuberDinner.Application.Menus.Commands.CreateMenu;
using BuberDinner.Contracts.Menus;
// using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers
{
    
    [Route("hosts/{hostId}/menus")]
    public class MenuController : ApiController
    {

      private readonly IMapper _mapper;
      private readonly ISender _mediator;
      


        public MenuController(IMapper mapper , ISender mediator)
        {
            _mapper = mapper;
            _mediator = mediator; 
        }

        [HttpPost()]
        [AllowAnonymous]
              public async Task<IActionResult> CreateMenu([FromBody] CreateMenuRequest request, string hostId)
                        {
                            // Utilisez AutoMapper pour mapper CreateMenuRequest à CreateMenuCommand, sans HostId
                                var command = _mapper.Map<CreateMenuCommand>(request);

                                // Créez une nouvelle instance de CreateMenuCommand avec HostId initialisé, en utilisant la méthode `with`
                                var commandWithHostId = command with { HostId = hostId };

                                var createMenuResult = await _mediator.Send(commandWithHostId);
                                return createMenuResult.Match(
                                    menu => Ok(_mapper.Map<MenuResponse>(menu)),
                                    errors => Problem(errors)
                                );
                        }

    }
}