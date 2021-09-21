using System;

namespace Booking.Persistence.Models
{
    public class Booking
    {
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public User User { get; set; }
        public DateTime CreationDate { get; set; }
        public Guid RoomId { get; set; }
        public Guid HotelId { get; set; }
    }
}
