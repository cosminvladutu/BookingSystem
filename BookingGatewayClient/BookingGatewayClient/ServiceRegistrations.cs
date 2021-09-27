using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BookingGatewayClient
{
    internal static class ServiceRegistrations
    {
        public static void ConfigureServices(IServiceCollection builderServices, IConfiguration configuration)
        {
            builderServices
                .AddHttpClients()
                .AddLogging();

        }

        private static IServiceCollection AddHttpClients(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddHttpClient<IBookingReaderClient, BookingReaderClient>();

            return serviceCollection;
        }
    }
}