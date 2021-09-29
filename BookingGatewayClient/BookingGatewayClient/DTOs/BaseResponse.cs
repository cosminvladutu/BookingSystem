using System.Net;

namespace BookingGatewayClient.DTOs
{
    public class BaseResponse
    {
        public HttpStatusCode UpperStreamStatus { get; set; }
    }
}
