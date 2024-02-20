using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErrorOr;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BuberDinner.Api.Controllers
{
     [ApiController]
    // [AllowAnonymous]
    [Authorize]
    public class ApiController : ControllerBase
    {
        // [AllowAnonymous]
        protected IActionResult Problem(List<Error> errors)
        {
            if (errors.Count is 0) return Problem();

            if (errors.All(error => error.Type == ErrorType.Validation))
            {
                return ValidationProblem(errors);
            }
            HttpContext.Items["errors"] = errors;
            var firstError = errors[0];
            return Problem(firstError);
        }

        // [AllowAnonymous]

        private IActionResult Problem(Error firstError)
        {
            var statusCode = firstError.Type switch
            {
                ErrorType.Conflict => StatusCodes.Status409Conflict,
                ErrorType.Validation => StatusCodes.Status400BadRequest,
                ErrorType.NotFound => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError

            };

            return Problem(statusCode: statusCode, title: firstError.Description);
        }
        // [AllowAnonymous]
        private IActionResult ValidationProblem(List<Error> errors)
        {
            var modelStateDictionary = new ModelStateDictionary();
            foreach (var error in errors)
            {
                modelStateDictionary.AddModelError(
                  error.Code,
                  error.Description
                );
            }
            return ValidationProblem(modelStateDictionary);
        }
    }
}