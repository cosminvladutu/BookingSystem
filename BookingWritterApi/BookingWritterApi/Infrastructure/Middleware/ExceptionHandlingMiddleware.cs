using BookingWritterApi.Infrastructure.ViewModels;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Net;
using System.Threading.Tasks;

namespace BookingWritterApi.Infrastructure.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                Log.Error($"Booking Writter exception: {ex}");
                await HandleExceptionAsync(httpContext);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            await context.Response.WriteAsync(JsonConvert.SerializeObject(new ErrorViewModel
            {
                ErrorReason = "Internal Server Error from Booking Writter Api.",
            }));
        }
    }

    
}
