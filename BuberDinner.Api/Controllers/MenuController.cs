using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Contracts.Menus;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers
{
    
    [Route("hosts/{hostId}/menus")]
    public class MenuController : ApiController
    {

      [HttpPost]
      public IActionResult CreateMenu(
        CreateMenuRequest request , 
        string hostId
      )
      {
        return Ok(request);
      }

    }
}