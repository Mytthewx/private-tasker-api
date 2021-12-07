using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using PrivateTaskerAPI.Exceptions;
using System;
using System.Threading.Tasks;

namespace PrivateTaskerAPI.Middleware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch(ApiException apiException)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync(apiException.Message);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);

                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("Something went wrong.");
            }
        }
    }
}
