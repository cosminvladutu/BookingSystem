using Microsoft.Extensions.Configuration;

namespace Booking.Persistence
{
    public class ConnectionStringProvider : IConnectionStringProvider
    {
        private readonly IConfigurationRoot _configurationRoot;

        public ConnectionStringProvider()
        {
            _configurationRoot = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
        }

        public ConnectionStringProvider(IConfigurationRoot configurationRoot)
        {
            _configurationRoot = configurationRoot;
        }

        public string GetByName(string name)
        {
            return _configurationRoot.GetConnectionString(name);
        }
    }
}
