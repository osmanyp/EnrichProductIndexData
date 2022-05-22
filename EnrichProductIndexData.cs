using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Models;
using Helpers;

namespace Imcdi.AzureFunctions.Marketplace.EnrichProductIndexData
{
    public static class EnrichProductIndexData
    {
        [FunctionName("EnrichProductIndexData")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log,
            ExecutionContext executionContext)
        {
            IEnumerable<WebApiRequestRecord> requestRecords = WebApiSkillHelpers.GetRequestRecords(req, log);

            if(requestRecords == null)
            {
                return new BadRequestObjectResult("Bad Request");
            }

            WebApiSkillResponse response = WebApiSkillHelpers.ProcessRequestRecords(executionContext.FunctionName, requestRecords, SkillProcessor.Process);
            return new OkObjectResult(response);
        }
    }
}
