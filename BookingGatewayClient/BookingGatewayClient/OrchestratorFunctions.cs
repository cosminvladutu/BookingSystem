using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace BookingGatewayClient
{
    public static class OrchestratorFunctions
    {
        [FunctionName(nameof(BookingOrchestrator))]
        public static async Task<ListOfBookingsForUser> BookingOrchestrator(
            [OrchestrationTrigger] IDurableOrchestrationContext context)
        {
            context.SetCustomStatus(Status.Starting.ToString());

            context.SetCustomStatus(Status.GetInputAsString.ToString());

            var req = context.GetInput<string>();

            context.SetCustomStatus(Status.DeserializeInput.ToString());

            var booking = JsonConvert.DeserializeObject<CreateBooking>(req);

            var url = Environment.GetEnvironmentVariable("BookingWriterApiUrl");
            var headers = new Dictionary<string, StringValues>() { { "Content-Type", "application/json" } };

            context.SetCustomStatus(Status.CreatingBooking.ToString());

            var createRequest = new DurableHttpRequest(HttpMethod.Post,
                new Uri(url), headers, JsonConvert.SerializeObject(booking));
            DurableHttpResponse restartResponse = await context.CallHttpAsync(createRequest);
            context.SetCustomStatus(Status.BookingCreated.ToString());

            context.SetCustomStatus(Status.GettingBookings.ToString());

            var bookings = await context.CallActivityWithRetryAsync<ListOfBookingsForUser>(nameof(GetAllBookingForUserActivity),
               new RetryOptions(TimeSpan.FromSeconds(5), 3),
               booking.UserId);

            context.SetCustomStatus(Status.Completed.ToString());

            return bookings;
        }
    }
}