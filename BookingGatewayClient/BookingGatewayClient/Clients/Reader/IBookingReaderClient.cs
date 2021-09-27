using System;
using System.Threading.Tasks;

namespace BookingGatewayClient
{
    public interface IBookingReaderClient
    {
       Task<ListOfBookingsForUser> ListBookingsForUser(Guid Id); 
    }
}