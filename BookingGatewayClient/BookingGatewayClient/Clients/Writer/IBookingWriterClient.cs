using System.Threading.Tasks;

namespace BookingGatewayClient
{
    public interface IBookingWriterClient
    {
        Task CreateNewBooking(CreateBooking request);
    }
}
