using System;

namespace Booking.Models
{
    public class BookingLocationIdentifiers
    {
        public Identity RoomIdentity { get; private set; }
        public Identity HotelIdentity { get; private set; }

        private BookingLocationIdentifiers(Guid roomId, Guid hotelId)
        {
            RoomIdentity = Identity.Create(roomId);
            HotelIdentity = Identity.Create(hotelId);
        }

        internal static BookingLocationIdentifiers Create(Guid roomId, Guid hotelId)
        {
           return new BookingLocationIdentifiers(roomId, hotelId);
        }
    }
}