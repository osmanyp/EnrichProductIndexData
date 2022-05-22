using System.Collections.Generic;
using System.Linq;
using Models;
using Models.imcdi;

namespace Imcdi.AzureFunctions.Marketplace.EnrichProductIndexData
{
    public static class SkillProcessor
    {
        const string ProductDocumentType = "Product";
        const int DefaultManufacturerScore = 70;
        public static WebApiResponseRecord Process(WebApiRequestRecord request, WebApiResponseRecord response)
        {
            if (request.Data.DocumentType == ProductDocumentType)
            {
                response.Data.Keywords = GetKeywords(request.Data.Categories);
                response.Data.ManufacturerScore = GetManufacturerScore(
                request.Data.InStock, 
                request.Data.Style, 
                request.Data.Color, 
                request.Data.Material);
            }
            else
            {
                response.Data.Keywords = new List<string>();
                response.Data.ManufacturerScore = DefaultManufacturerScore;
            }

            return response;
        }

        public static List<string> GetKeywords(IEnumerable<Category> categories)
        {
            List<string> keywords = new List<string>();

            foreach(var item in categories)
            {
                keywords.Add(item.Name);
            }

            return keywords;
        }

        public static int GetManufacturerScore(bool inStock, IEnumerable<string> styles, IEnumerable<string> colors,
            IEnumerable<string> materials)
        {
            var score = 0;
            
            if (inStock)
            {
                score += 50;
            }

            if (styles.Any())
            {
                score += 10;
            }

            if (colors.Any())
            {
                score += 10;
            }

            if (materials.Any())
            {
                score += 10;
            }

            return score;
        }
    }
}