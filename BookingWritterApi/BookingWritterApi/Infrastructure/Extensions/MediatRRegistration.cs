using Booking.Actions.Commands;
using BookingWritterApi.Infrastructure.Pipeline;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BookingWritterApi.Infrastructure.Extensions
{
    public static class MediatRRegistration
    {
        public static void RegisterMediatrServices(this IServiceCollection services)
        {
            services.AddMediatR(typeof(MediatrAssemblyInfo).Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(MediatrSendPipeline<,>));
            services.Decorate(typeof(INotificationHandler<>), typeof(LogMediatRNotificationDecorator<>));
        }
    }
}
