
using System.Collections.Generic;

namespace Models.imcdi
{
    public class Category
    {
        public int CategoryId { get; set; }

        public string Name { get; set; }

        public string FullPath { get; set; }

        public string UrlFriendlyName { get; set; }

        public string UrlFriendlyFullPath { get; set; }

        public IEnumerable<Parent> Parents { get; set; } = new List<Parent>();

        public Category()
        {

        }
    }
}