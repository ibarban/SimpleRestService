using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System.Net;

namespace SimpleRestService
{
    public class Function1
    {
        private static int requestCount = 0;

        private readonly ILogger<Function1> _logger;

        public Function1(ILogger<Function1> logger)
        {
            _logger = logger;
        }

        [Function("health")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            return new OkObjectResult("Welcome to Azure Functions!");
        }

        [Function("run")]
        public static IActionResult Helath(
            [HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequest req)
        {
            requestCount++;

            if (requestCount >= 500)
            {
                return new StatusCodeResult((int)HttpStatusCode.ServiceUnavailable);
            }

            return new OkResult();
        }
    }
}
