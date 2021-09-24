using System.Collections.Generic;

namespace Booking.Messages.Queries
{
    public class ListOfBookingsQueryResponse
    {
        public IList<BookingVm> Active { get; set; }
        public IList<BookingVm> History { get; set; }
    }
}
