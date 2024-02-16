using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;

namespace BuberDinner.Api.MiddleWare
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try{
                await _next(context);
            }

            catch(Exception ex)
            {
                await HandleExceptionAsync(context, ex);
 
            }
        }

        private static  Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var code = HttpStatusCode.InternalServerError; 
            var result = JsonSerializer.Serialize( new {error = "An error occured while processing"});
            context.Response.ContentType  ="application/json";
            context.Response.StatusCode = (int)code; 
            return  context.Response.WriteAsync(result);
            


        }
    }
}