using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace BookingGatewayClient
{
    public static class HttpFunctions
    {
        private const string inputInvalidErrorMessage = "Input not valid";

        [FunctionName(nameof(HttpBookingClientStarter))]
        public static async Task<HttpResponseMessage> HttpBookingClientStarter(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequestMessage req,
            [DurableClient] IDurableOrchestrationClient starter,
            ILogger log)
        {

            var reqContent = await req.Content.ReadAsStringAsync();

            string instanceId = await starter.StartNewAsync(nameof(OrchestratorFunctions.BookingOrchestrator), null, reqContent);
            string startOrchestratorMessage = $"Started orchestration with ID = '{instanceId}'.";
            log.LogInformation(startOrchestratorMessage);

            return starter.CreateCheckStatusResponse(req, instanceId);
        }
    }
}