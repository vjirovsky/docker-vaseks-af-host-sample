using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace SampleFunctionApp
{
    public static class HealthcheckFunction
    {
        [FunctionName("HealthcheckFunction")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "healthcheck/")] HttpRequest req,
            ILogger log)
        {
            bool isError = false;
            string errorMessage = String.Empty;

            /*
             * custom checks
             */
            //isError = true;
            //errorMessage = "Custom check XYZ failed";

            if (isError)
            {
                return (ActionResult) new BadRequestObjectResult(errorMessage);
            }
            else
            {
                return (ActionResult)new OkObjectResult("OK");
            }
        }
    }
}
