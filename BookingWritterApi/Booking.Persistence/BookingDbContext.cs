using Booking.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace Booking.Persistence
{
    public class BookingDbContext : DbContext
    {
        public DbSet<Models.Booking> Booking { get; set; }
        public DbSet<Hotel> Hotel { get; set; }

        public BookingDbContext(DbContextOptions<BookingDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
