using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace WebFramwork.Middlewares
{
   public class CustomExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        public CustomExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
       public async Task  Invoke(HttpContext httpContext)
        {

        }
    }
   
}
