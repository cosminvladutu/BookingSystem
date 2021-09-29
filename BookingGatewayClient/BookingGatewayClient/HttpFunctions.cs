using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Threading.Tasks;

namespace BookingGatewayClient
{
    public static class HttpFunctions
    {
        private const string inputInvalidErrorMessage = "Input not valid";

        [FunctionName(nameof(HttpBookingClientStarter))]
        public static async Task<IActionResult> HttpBookingClientStarter(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequest req,
            [DurableClient] IDurableOrchestrationClient starter,
            ILogger log)
        {
            //valitate & deserialize
            var reqContent = await new StreamReader(req.Body).ReadToEndAsync();

            string instanceId = await starter.StartNewAsync(nameof(OrchestratorFunctions.BookingOrchestrator), null, reqContent);
            string startOrchestratorMessage = $"Started orchestration with ID = '{instanceId}'.";
            log.LogInformation(startOrchestratorMessage);

            return starter.CreateCheckStatusResponse(req, instanceId);
        }
    }
}