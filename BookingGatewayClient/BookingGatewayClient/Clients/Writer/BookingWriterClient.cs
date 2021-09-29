using BookingGatewayClient.DTOs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BookingGatewayClient
{
    public class BookingWriterClient : IBookingWriterClient
    {
        private const string _contentType = "application/json";
        private const string _invalidBookingWritterUrlMessage = "Booking Writter API Url is null or empty";
        private const string _badRequestErrorMessage = "Bad request on the creation of the booking.";
        private const string _creationNotMadeMessafe = "Creation was not made";
        private readonly HttpClient _client;
        private readonly ILogger<BookingWriterClient> _log;

        public BookingWriterClient(HttpClient client, ILogger<BookingWriterClient> log)
        {
            _client = client;
            _log = log;
        }
        public async Task CreateNewBooking(CreateBooking createBooking)
        {
            var postUri = GetCreateBookingURI();
            var serviceRequest = CreateHttpContentRequest(createBooking);
            HttpResponseMessage httpResponse;
            try
            {
                httpResponse = await _client.PostAsync(postUri, serviceRequest);
            }
            catch(HttpRequestException reqEx)
            {
                _log.LogError(reqEx.Message);
                throw new Exception(_creationNotMadeMessafe);
            }

            if (httpResponse.StatusCode == HttpStatusCode.OK)
            {
                return;
            }
            if (httpResponse.StatusCode == HttpStatusCode.BadRequest)
            {
                _log.LogError(_badRequestErrorMessage);
                throw new Exception(_creationNotMadeMessafe);
            }
            if (httpResponse.StatusCode == HttpStatusCode.InternalServerError)
            {
                string responseContent = await httpResponse.Content.ReadAsStringAsync();
                var errorResponse = JsonConvert.DeserializeObject<ErrorResponseFromService>(responseContent);
                _log.LogError(errorResponse.ErrorReason);
                throw new Exception(_creationNotMadeMessafe);
            }
        }

        private Uri GetCreateBookingURI()
        {
            var url = Environment.GetEnvironmentVariable("BookingWriterApiUrl");
            if (string.IsNullOrEmpty(url))
            {
                throw new Exception(_invalidBookingWritterUrlMessage);
            }
            return new Uri(url);
        }
        private HttpContent CreateHttpContentRequest(CreateBooking request)
        {
            var payload = JsonConvert.SerializeObject(request);
            return new StringContent(payload, Encoding.UTF8, _contentType);
        }
    }
}
