using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers
{

    [Route("[controller]")]
    [Authorize]
    public class DinnerController : ApiController
    {
        [HttpGet]
        public IActionResult ListDinner()
        {
            //return Ok(Array.Empty<string>());
            return Ok("ok");
        }
    }
}