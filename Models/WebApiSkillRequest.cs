using System.Collections.Generic;

namespace Models
{
    public class WebApiSkillRequest
    {
        public IEnumerable<WebApiRequestRecord> Values { get; set; } = new List<WebApiRequestRecord>();
    }
}