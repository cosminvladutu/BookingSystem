using MediatR;
using System;
using System.Collections.Generic;

namespace Booking.Messages
{
    public class CreateBookingCommandRequest : INotification
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid RoomId { get; set; }
        public Guid HotelId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
