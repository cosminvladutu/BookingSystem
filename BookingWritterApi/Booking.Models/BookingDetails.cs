using System;

namespace Booking.Models
{
    public class BookingDetails
    {
        public Identity UserId { get; private set; }
        public DateTime CreationDate { get; private set; }
        public BookingLocationIdentifiers Location { get; private set; }
        private BookingDetails(Guid roomId, Guid hotelId, Guid userId)
        {
            UserId = Identity.Create(userId);
            CreationDate = DateTime.Now;
            Location = BookingLocationIdentifiers.Create(roomId, hotelId);
        }

        internal static BookingDetails Create(Guid roomId, Guid hotelId, Guid userId)
        {
            return new BookingDetails(roomId, hotelId, userId);
        }
    }
}