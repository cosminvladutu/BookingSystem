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
                return new BadRequestObjectResult("Input not given");
            }

            if (!Guid.TryParse(userIdParam, out Guid userId))
            {
                return new BadRequestObjectResult("Input not valid");
            }
            string instanceId = await starter.StartNewAsync(nameof(OrchestratorFunctions.BookingOrchestrator), null, userId);
            log.LogInformation($"Started orchestration with ID = '{instanceId}'.");

            return starter.CreateCheckStatusResponse(req, instanceId);
        }
    }
}