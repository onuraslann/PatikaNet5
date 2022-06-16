using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Patika.WebApi.Services;
using System;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;

namespace Patika.WebApi.Middleware
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerService _loggerService;
        public CustomExceptionMiddleware(RequestDelegate next, ILoggerService loggerService)
        {
            _next = next;
            _loggerService = loggerService;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var watch = Stopwatch.StartNew();
            try
            {
               
                string message = "[Request] Http" + httpContext.Request.Method + " -- " + httpContext.Request.Path;
                _loggerService.Write(message);
                await _next(httpContext);
                watch.Stop();
                message = "[Response] Http" + httpContext.Request.Method + " -- " + httpContext.Request.Path + "  responed  : " + httpContext.Response.StatusCode
                    + " in " + watch.Elapsed.TotalMilliseconds + "  Ms  ";
                _loggerService.Write(message);
            }
            catch (Exception ex)
            {
                watch.Stop();
                await HandleException(httpContext, ex, watch);
            }
          
        }

        private Task HandleException(HttpContext httpContext, Exception ex, Stopwatch watch)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
            string message = "[Error]   Http" +  httpContext.Request.Method + "  -  " +   httpContext.Response.StatusCode + " ErrorMessage " +  ex.Message

              + " in " +    watch.Elapsed.TotalMilliseconds + " ms  " ;
            _loggerService.Write(message);


            var result = JsonConvert.SerializeObject(new { error = ex.Message }, Formatting.None);
            return httpContext.Response.WriteAsync(result);
        }
    }




    public static class CustomExceptionMiddlewareExtensions
    {

        public static IApplicationBuilder UseCustomExceptionMiddleware(this IApplicationBuilder builder)
        {


            return builder.UseMiddleware<CustomExceptionMiddleware>();

        }
    }
}
