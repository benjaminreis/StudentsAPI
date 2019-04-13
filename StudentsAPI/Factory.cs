using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace StudentsAPI
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    internal class Factory
    {
        private readonly RequestDelegate _next;

        public Factory(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {

            return _next(httpContext);
        }



    }

    //// Extension method used to add the middleware to the HTTP request pipeline.
    //public static class FactoryExtensions
    //{
    //    public static IApplicationBuilder UseMiddlewareClassTemplate(this IApplicationBuilder builder)
    //    {
    //        return builder.UseMiddleware<Factory>();
    //    }
    //}
}
