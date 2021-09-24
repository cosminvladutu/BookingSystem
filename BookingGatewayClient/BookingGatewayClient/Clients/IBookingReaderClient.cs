using System;
using System.Threading.Tasks;

namespace BookingGatewayClient
{
    public interface IBookingReaderClient
    {
       Task<BookingItem> ListBookingsForUser(Guid Id); 
    }
}