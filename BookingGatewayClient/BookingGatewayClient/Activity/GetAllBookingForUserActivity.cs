using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace BookingGatewayClient
{
    public class GetAllBookingForUserActivity
    {
        private readonly IBookingReaderClient _client;

        public GetAllBookingForUserActivity(IBookingReaderClient client)
        {
            _client = client;
        }

        [FunctionName(nameof(GetAllBookingForUserActivity))]
        public async Task<BookingItem> Run([ActivityTrigger] Guid id, ILogger log)
        {
            try
            {
                return await _client.ListBookingsForUser(id);
            }
            catch (Exception e)
            {
                log.LogError(e.Message);
                Console.WriteLine(e);
                throw;
            }
        }
    }

}
