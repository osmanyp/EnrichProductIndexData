using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Models;
using Newtonsoft.Json;

namespace Helpers
{
    public static class WebApiSkillHelpers
    {
        public static WebApiSkillResponse ProcessRequestRecords(string functionName, IEnumerable<WebApiRequestRecord> requestRecords, Func<WebApiRequestRecord, WebApiResponseRecord, WebApiResponseRecord> processRecord)
        {
            WebApiSkillResponse response = new WebApiSkillResponse();

            foreach (WebApiRequestRecord inRecord in requestRecords)
            {
                WebApiResponseRecord outRecord = new WebApiResponseRecord() { RecordId = inRecord.RecordId };

                try
                {
                    outRecord = processRecord(inRecord, outRecord);
                }
                catch (Exception e)
                {
                    outRecord.Errors.Add(new WebApiErrorWarningContract() { Message = $"{functionName} - Error processing the request record : {e.ToString() }" });
                }
                response.Values.Add(outRecord);
            }

            return response;
        }

        public static IEnumerable<WebApiRequestRecord> GetRequestRecords(HttpRequest req, ILogger log)
        {
            string jsonRequest = new StreamReader(req.Body).ReadToEnd();
            if(String.IsNullOrEmpty(jsonRequest))
            {
                return null;
            }
            WebApiSkillRequest docs = JsonConvert.DeserializeObject<WebApiSkillRequest>(jsonRequest);
            return docs.Values;
        }
    }
}