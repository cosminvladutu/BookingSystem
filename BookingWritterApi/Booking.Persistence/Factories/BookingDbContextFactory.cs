using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Booking.Persistence.Factories
{
    public class BookingDbContextFactory : IDesignTimeDbContextFactory<BookingDbContext>
    {
        private readonly IConnectionStringProvider _connectionStringProvider;

        public BookingDbContextFactory()
        {
            _connectionStringProvider = new ConnectionStringProvider();
        }

        internal BookingDbContextFactory(IConnectionStringProvider connectionStringProvider)
        {
            _connectionStringProvider = connectionStringProvider;
        }

        public BookingDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BookingDbContext>()
               .UseSqlServer(_connectionStringProvider.GetByName("Default"))
               .EnableSensitiveDataLogging();
            return new BookingDbContext(optionsBuilder.Options);
        }
    }
}
