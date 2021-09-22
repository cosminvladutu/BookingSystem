using Microsoft.EntityFrameworkCore;

namespace Booking.Persistence
{
    public class BookingDbContext : DbContext
    {
        public DbSet<Entities.Booking> Booking { get; set; }

        public BookingDbContext(DbContextOptions<BookingDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
