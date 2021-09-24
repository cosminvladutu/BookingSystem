using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BookingGatewayClient
{
    public class BookingReaderClient : IBookingReaderClient
    {
        private readonly HttpClient _client;

        public BookingReaderClient(HttpClient client)
        {
            _client = client;
        }
        public async Task<BookingItem> ListBookingsForUser(Guid id)
        {
            var bookingReaderApiUrl = Environment.GetEnvironmentVariable("BookingReaderApiUrl");
            var uri = new Uri($"{bookingReaderApiUrl}{id}");
            var httpResponse = await _client.GetAsync(uri);
            var content = await httpResponse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<BookingItem>(content);
        }
    }
}