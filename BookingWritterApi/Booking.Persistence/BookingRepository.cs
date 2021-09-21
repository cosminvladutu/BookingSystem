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
            var user = _dbContext.User.SingleOrDefault(s => s.Id == booking.Details.UserId.Id);
            var hotel = _dbContext.Hotel.SingleOrDefault(s => s.Id == booking.Details.Location.HotelId.Id);
            var room = _dbContext.Room.SingleOrDefault(s => s.Id == booking.Details.Location.RoomId.Id);
            var toSave = new Entities.Booking
            {
                CreationDate = booking.Details.CreationDate,
                EndDate = booking.Interval.EndDate,
                StartDate = booking.Interval.StartDate,
                Id = booking.Id.Id,
                User = user,
                Hotel = hotel,
                Room = room
                
            };
            await _dbContext.Booking.AddAsync(toSave);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> BookingExists(Guid id)
        {
            return _dbContext.Booking.Any(s => s.Id == id);
        }
    }
}
