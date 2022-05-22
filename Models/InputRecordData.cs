using System.Collections.Generic;
using Models.imcdi;

namespace Models
{
    public class InputRecordData
    {
        public bool InStock { get; set; }
        public string DocumentType { get; set; }
        public IEnumerable<string> Style { get; set; }
        public IEnumerable<string> Material { get; set; }
        public IEnumerable<string> Color { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        
    }
}