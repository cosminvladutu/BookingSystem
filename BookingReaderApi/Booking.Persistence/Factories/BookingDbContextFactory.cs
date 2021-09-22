using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Booking.Persistence.Factories
{
    public class BookingDbContextFactory : IDesignTimeDbContextFactory<BookingDbContext>
    {
        private readonly IConfigurationRoot _configurationRoot;

        internal BookingDbContextFactory(IConfigurationRoot configurationRoot)
        {
            _configurationRoot = configurationRoot;
        }

        public BookingDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BookingDbContext>()
               .UseSqlServer(_configurationRoot.GetConnectionString("Default"))
               .EnableSensitiveDataLogging();
            return new BookingDbContext(optionsBuilder.Options);
        }
    }
}
