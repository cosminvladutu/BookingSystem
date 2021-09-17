using System;
using System.Collections.Generic;

namespace Booking.Models
{
    public class BookingItem
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }

        public IList<Guid> RoomList { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
