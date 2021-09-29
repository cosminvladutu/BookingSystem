using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookingGatewayClient
{
    internal static class ServiceRegistrations
    {
        public static void ConfigureServices(IServiceCollection builderServices, IConfiguration configuration)
        {
            builderServices
                .AddHttpClients();
        }

        private static IServiceCollection AddHttpClients(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddHttpClient<IBookingReaderClient, BookingReaderClient>();
            serviceCollection.AddHttpClient<IBookingWriterClient, BookingWriterClient>();

            return serviceCollection;
        }
    }
}