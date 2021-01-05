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
using Common;
using WebFramwork.Api;

namespace WebFramwork.Middlewares
{
   public class CustomExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomExceptionHandlingMiddleware> _logger;

        public CustomExceptionHandlingMiddleware(RequestDelegate next,ILogger<CustomExceptionHandlingMiddleware> logger)
        {
            this._next = next;
            this._logger = logger;
        }


        public async Task  Invoke(HttpContext httpContext)
        {
            try
            {
               await _next(httpContext);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex,"خطای ناشناخته رخ داده است");
                var apiResult = new ApiResult(false, ApiResultStatusCode.ServerError);
                var json =JsonConvert.SerializeObject(apiResult);
                await httpContext.Response.WriteAsync(json);
            }
        }
    }
   
}
