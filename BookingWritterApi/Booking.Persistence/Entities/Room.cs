using System;

namespace Booking.Persistence.Entities
{
    public class Room
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public Hotel Hotel { get; set; }
        public Guid HotelId { get; set; }
    }
}
