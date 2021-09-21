using Booking.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;

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
            //var builder = new DbContextOptionsBuilder<BookingDbContext>();
            //builder.UseSqlServer(_connectionStringProvider.GetByName("Default"),
            //    sql => sql.MigrationsAssembly(typeof(BookingDbContextFactory).GetTypeInfo().Assembly.GetName().Name));

            //return new BookingDbContext(builder.Options);


            var optionsBuilder = new DbContextOptionsBuilder<BookingDbContext>()
               .UseSqlServer(_connectionStringProvider.GetByName("Default"));
            return new BookingDbContext(optionsBuilder.Options);


            //var optionsBuilder = new DbContextOptionsBuilder<BookingDbContext>();
            //optionsBuilder.UseSqlServer(@"Server=COSMIN-VLADUTU\SQLEXPRESS\;Database=TestDb;Trusted_Connection=True;");
            //return new BookingDbContext(optionsBuilder.Options);
        }
    }
}
