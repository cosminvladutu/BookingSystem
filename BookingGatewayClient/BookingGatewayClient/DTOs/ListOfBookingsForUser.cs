using System.Collections.Generic;

namespace BookingGatewayClient
{
    public class ListOfBookingsForUser
    {
        /// <summary>
        /// The list of active bookings.
        /// </summary>
        public IList<Booking> Active { get; set; }
        /// <summary>
        /// The history list of your bookings (bookings from the past).
        /// </summary>
        public IList<Booking> History { get; set; }
    }
}