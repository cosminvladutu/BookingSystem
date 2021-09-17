using BookingWritterApi.Infrastructure.Middleware;
using Microsoft.AspNetCore.Builder;

namespace BookingWritterApi.Infrastructure.Extensions
{
    /// <summary>
    ///     Extension method used to add the middleware to the HTTP request pipeline.
    /// </summary>
    public static class ExceptionHandlingMiddlewareExtensions
    {
        /// <summary>
        ///     Uses the exception handling middleware.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns>The application builder with exception handler added.</returns>
        public static IApplicationBuilder UseExceptionHandlingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}
