using System;

namespace Booking.Models
{
    public class BookingLocationIdentifiers
    {
        public Identity RoomId { get; private set; }
        public Identity HotelId { get; private set; }

        private BookingLocationIdentifiers(Guid roomId, Guid hotelId)
        {
            RoomId = Identity.Create(roomId);
            HotelId = Identity.Create(hotelId);
        }

        internal static BookingLocationIdentifiers Create(Guid roomId, Guid hotelId)
        {
           return new BookingLocationIdentifiers(roomId, hotelId);
        }
    }
}