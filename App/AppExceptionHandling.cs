using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace StockportGovUK.AspNetCore.Middleware.App
{
    public class AppExceptionHandling: ExceptionHandling
    {
        public AppExceptionHandling(RequestDelegate next, ILogger<ExceptionHandling> logger, IConfiguration configuration): base(next, logger, configuration)
        {
        }

        protected override async Task HandleResponse(HttpContext context, Exception exception, HttpStatusCode statusCode = HttpStatusCode.InternalServerError)
        {
            var errorRoute = _configuration.GetValue<string>("ErrorRoute");

            if(string.IsNullOrEmpty(errorRoute))
            {
                context.Response.StatusCode = (int)statusCode;
                context.Response.Redirect("/Error");
            }

            context.Response.Redirect(errorRoute);
        }
    }
}