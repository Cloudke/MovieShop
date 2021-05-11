using ApplicationCore.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MovieShop.API.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class MovieShopExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public MovieShopExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try { 
                await _next(httpContext); 
            }
            catch(Exception e) {
                await HandleException(httpContext,e);
            }
        }


        private async Task HandleException(HttpContext httpContext,Exception ex)
        {
            //always give user friendly msg, never send actual exception to the user
            //log the exception,text files,db,json files
            //date time,err msg,stack trace, user
            //send notification to development team email
            //send proper http status codes.

            switch (ex)
            {
                case ConflictException:
                    httpContext.Response.StatusCode = (int)HttpStatusCode.Conflict;
                    break;
                case NotFoundException:
                    httpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;
                case UnauthorizedAccessException:
                    httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    break;
                case Exception:
                    httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MovieShopExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseMovieShopExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MovieShopExceptionMiddleware>();
        }
    }
}
