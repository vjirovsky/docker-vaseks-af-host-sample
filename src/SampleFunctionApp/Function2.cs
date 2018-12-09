using System;
using System.Net;
using System.Net.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace SampleFunctionApp
{
    public static class Function2
    {
        [FunctionName("Function2")]
        public static HttpResponseMessage Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]HttpRequestMessage req,
            ILogger log
        )
        {
            log.LogInformation("Function 2 - I am OK!");

            
            return req.CreateResponse(HttpStatusCode.OK, "pong;" + log.GetType().ToString());
        }
    }
}
