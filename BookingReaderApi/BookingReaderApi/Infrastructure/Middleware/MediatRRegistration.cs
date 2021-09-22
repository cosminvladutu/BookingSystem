using Booking.Actions.Queries;
using BookingReaderApi.Infrastructure.Pipeline;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BookingReaderApi.Infrastructure.Middleware
{
    public static class MediatRRegistration
    {
        public static void RegisterMediatrServices(this IServiceCollection services)
        {
            services.AddMediatR(typeof(MediatrAssemblyInfo).Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(MediatrSendPipeline<,>));
        }
    }
}
