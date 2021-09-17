using System;

namespace Booking.Messages.Commands
{
    public class CreateBookingCommandRequest
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public Guid RoomId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
