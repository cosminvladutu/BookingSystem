using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;

namespace BookingGatewayClient
{
    public static class HttpFunctions
    {
        private const string inputInvalidErrorMessage = "Input error";

        [FunctionName(nameof(HttpBookingClientStarter))]
        public static async Task<IActionResult> HttpBookingClientStarter(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequest req,
            [DurableClient] IDurableOrchestrationClient starter,
            ILogger log)
        {
            string reqContent;
            CreateBooking booking;

            try
            {
                reqContent = await new StreamReader(req.Body).ReadToEndAsync();
                booking = JsonConvert.DeserializeObject<CreateBooking>(reqContent);
            }
            catch (Exception ex)
            {
                log.LogError(ex.Message);
                return new BadRequestObjectResult("inputInvalidErrorMessage");
            }

            string instanceId = await starter.StartNewAsync(nameof(OrchestratorFunctions.BookingOrchestrator), null, booking);
            string startOrchestratorMessage = $"Started orchestration with ID = '{instanceId}'.";
            log.LogInformation(startOrchestratorMessage);

            return starter.CreateCheckStatusResponse(req, instanceId);
        }
    }
}