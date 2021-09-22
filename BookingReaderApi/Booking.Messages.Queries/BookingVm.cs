using System;

namespace Booking.Messages.Queries
{
    public class BookingVm
    {
        /// <summary>
        /// The start date of the booking.
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// The end date of the booking.
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// The date when the booking was made.
        /// </summary>
        public DateTime CreationDate { get; set; }
        /// <summary>
        /// The Room identifier.
        /// </summary>
        public Guid RoomId { get; set; }

        /// <summary>
        /// The Hotel identifier.
        /// </summary>
        public Guid HotelId { get; set; }
    }
}