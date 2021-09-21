using System;

namespace Booking.Persistence.Entities
{
    public class Booking
    {
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public User User { get; set; }
        public DateTime CreationDate { get; set; }
        public Room Room { get; set; }
        public Hotel Hotel { get; set; }
    }
}
