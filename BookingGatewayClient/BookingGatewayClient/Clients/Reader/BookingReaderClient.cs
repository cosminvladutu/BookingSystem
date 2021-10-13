using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BookingGatewayClient
{
    public class BookingReaderClient : IBookingReaderClient
    {
        private readonly HttpClient _client;
        private const string _invalidBookingReaderUrlMessage = "Booking Reader API Url is null or empty";

        public BookingReaderClient(HttpClient client)
        {
            _client = client;
        }
        public async Task<ListOfBookingsForUser> ListBookingsForUser(Guid id)
        {
            var getUri = GetBookingReaderURI(id);

            var httpResponse = await _client.GetAsync(getUri);
            var content = await httpResponse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ListOfBookingsForUser>(content);
        }

        private Uri GetBookingReaderURI(Guid id)
        {
            var url = Environment.GetEnvironmentVariable("BookingReaderApiUrl");
            if (string.IsNullOrEmpty(url))
            {
                throw new Exception(_invalidBookingReaderUrlMessage);
            }
            return new Uri($"{url}{id}");
        }
    }
}