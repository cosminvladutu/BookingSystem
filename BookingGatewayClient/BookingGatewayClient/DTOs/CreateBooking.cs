using System;

namespace BookingGatewayClient
{
    public class CreateBooking
    {
        /// <summary>
        /// The identifier of the booking, so that if 2 bookings will be received with the same id we will not save 2 different
        /// bookings.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The identifier of the user who made the booking.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// The Room identifier.
        /// </summary>
        public Guid RoomId { get; set; }

        /// <summary>
        /// The Hotel identifier.
        /// </summary>
        public Guid HotelId { get; set; }

        /// <summary>
        /// The start date of the booking.
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// The end date of the booking.
        /// </summary>
        public DateTime EndDate { get; set; }
    }
}
