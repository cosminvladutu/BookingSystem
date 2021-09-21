using Booking.Contracts;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.Persistence
{
    public class BookingRepository : IBookingRepository
    {
        private readonly BookingDbContext _dbContext;

        public BookingRepository(BookingDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Save(Models.Booking booking)
        {
            var toSave = new Entities.Booking();
            await _dbContext.Booking.AddAsync(toSave);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> BookingExists(Guid id)
        {
            return _dbContext.Booking.Any(s => s.Id == id);
        }
    }
}
