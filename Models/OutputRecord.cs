using System.Collections.Generic;

namespace Models
{
    public class OutputRecord
    {
        public double ManufacturerScore { get; set; }
        public IEnumerable<string> Keywords = new List<string>();
    }
}