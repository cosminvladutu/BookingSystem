using BookingGatewayClient;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

[assembly: FunctionsStartup(typeof(Startup))]
namespace BookingGatewayClient
{
    public class Startup : FunctionsStartup
    {
        private IConfiguration configuration;
        public override void Configure(IFunctionsHostBuilder builder)
        {
            this.configuration = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .Build();

            ServiceRegistrations.ConfigureServices(builder.Services, configuration);
        }

    }
}
