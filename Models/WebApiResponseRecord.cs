
using System.Collections.Generic;

namespace Models
{
    public class WebApiResponseRecord
    {
        public string RecordId { get; set; }
        public OutputRecord Data { get; set; } = new OutputRecord();
        public List<WebApiErrorWarningContract> Errors { get; set; } = new List<WebApiErrorWarningContract>();
        public List<WebApiErrorWarningContract> Warnings { get; set; } = new List<WebApiErrorWarningContract>();
    }
}