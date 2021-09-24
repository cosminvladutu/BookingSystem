using System.Collections.Generic;

namespace BookingGatewayClient
{
    public class BookingItem
    {
        public IList<Booking> Active { get; set; }
        public IList<Booking> History { get; set; }
    }
}