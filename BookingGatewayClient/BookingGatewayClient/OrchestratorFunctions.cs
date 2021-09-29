using BookingGatewayClient.Activity;
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

            var input = context.GetInput<CreateBooking>();

            context.SetCustomStatus(Status.CreatingBooking.ToString());

            await context.CallActivityAsync(nameof(CreateNewBookingActivity),input);

            context.SetCustomStatus(Status.BookingCreated.ToString());

            context.SetCustomStatus(Status.GettingBookings.ToString());

            var bookings = await context.CallActivityWithRetryAsync<ListOfBookingsForUser>(nameof(GetAllBookingForUserActivity),
               new RetryOptions(TimeSpan.FromSeconds(5), 3),
               input.UserId);

            context.SetCustomStatus(Status.Completed.ToString());

            return bookings;
        }
    }
}