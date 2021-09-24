using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using System;
using System.Threading.Tasks;

namespace BookingGatewayClient
{
    public static class OrchestratorFunctions
    {
        [FunctionName(nameof(BookingOrchestrator))]
        public static async Task<BookingItem> BookingOrchestrator(
            [OrchestrationTrigger] IDurableOrchestrationContext context)
        {
            context.SetCustomStatus(Status.Starting.ToString());

            var userId = context.GetInput<string>();

            context.SetCustomStatus(Status.GettingBookings.ToString());
         
            var bookings = await context.CallActivityWithRetryAsync<BookingItem>(nameof(GetAllBookingForUserActivity),
               new RetryOptions(TimeSpan.FromSeconds(5), 3),
               userId);
         
            context.SetCustomStatus(Status.Completed.ToString());
          
            return bookings;
        }
    }
}