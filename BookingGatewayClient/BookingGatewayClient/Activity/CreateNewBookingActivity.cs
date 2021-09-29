using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using System.Threading.Tasks;

namespace BookingGatewayClient.Activity
{
    public class CreateNewBookingActivity
    {
        private readonly IBookingWriterClient _client;

        public CreateNewBookingActivity(IBookingWriterClient client)
        {
            _client = client;
        }

        [FunctionName(nameof(CreateNewBookingActivity))]
        public async Task Run([ActivityTrigger] CreateBooking request)
        {
            await _client.CreateNewBooking(request);
        }
    }
}
