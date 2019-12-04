using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace StockportGovUK.AspNetCore.Middleware
{
    public class ExceptionHandling
    {
        protected readonly RequestDelegate _next;
        protected readonly ILogger<ExceptionHandling> _logger;

        protected readonly IConfiguration _configuration;

        public ExceptionHandling(RequestDelegate next, ILogger<ExceptionHandling> logger, IConfiguration configuration)
        {
            _next = next;
            _logger = logger;
            _configuration = configuration;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                await HandleResponse(context, ex);
            }
        }

        protected virtual async Task HandleResponse(HttpContext context, Exception exception, HttpStatusCode statusCode = HttpStatusCode.InternalServerError)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            await context.Response.WriteAsync(JsonConvert.SerializeObject(new 
            {
                Message = exception.Message,
                InnerException = exception.InnerException
            }));
        }
    }
}