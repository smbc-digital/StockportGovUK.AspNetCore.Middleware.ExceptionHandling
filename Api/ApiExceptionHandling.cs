using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace StockportGovUK.AspNetCore.Middleware
{
    public class ApiExceptionHandling : ExceptionHandling
    {
        public ApiExceptionHandling(RequestDelegate next, ILogger<ExceptionHandling> logger, IConfiguration configuration) : base(next, logger, configuration)
        {
        }

        protected override async Task HandleResponse(HttpContext context, Exception exception, HttpStatusCode statusCode = HttpStatusCode.InternalServerError)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            await context.Response.WriteAsync(JsonSerializer.Serialize(new 
            {
                Message = exception.Message,
                InnerException = exception.InnerException
            }));
        }
    }
}