using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;

namespace Patika.WebApi.Middleware
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var watch = Stopwatch.StartNew();
            try
            {
               
                string message = "[Request] Http" + httpContext.Request.Method + " -- " + httpContext.Request.Path;
                Console.WriteLine(message);
                await _next(httpContext);
                watch.Stop();
                message = "[Response] Http" + httpContext.Request.Method + " -- " + httpContext.Request.Path + "  responed  : " + httpContext.Response.StatusCode
                    + " in " + watch.Elapsed.TotalMilliseconds + "  Ms  ";
                Console.WriteLine(message);
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
            Console.WriteLine(message);
          

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
