using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookingGatewayClient
{
    public static class HttpFunctions
    {
        private const string inputNotGivenErrorMessage = "Input not given";
        private const string inputInvalidErrorMessage = "Input not valid";

        [FunctionName(nameof(HttpBookingClientStarter))]
        public static async Task<IActionResult> HttpBookingClientStarter(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequest req,
            [DurableClient] IDurableOrchestrationClient starter,
            ILogger log)
        {
            string userIdParam;
            try
            {
                userIdParam = req.GetQueryParameterDictionary()["userId"];
            }
            catch (KeyNotFoundException e)
            {
                log.LogWarning(e.Message);
                return new BadRequestObjectResult(inputNotGivenErrorMessage);
            }

            if (!Guid.TryParse(userIdParam, out Guid userId))
            {
                return new BadRequestObjectResult(inputInvalidErrorMessage);
            }
            string instanceId = await starter.StartNewAsync(nameof(OrchestratorFunctions.BookingOrchestrator), null, userId);
            string startOrchestratorMessage = $"Started orchestration with ID = '{instanceId}'.";
            log.LogInformation(startOrchestratorMessage);

            return starter.CreateCheckStatusResponse(req, instanceId);
        }
    }
}