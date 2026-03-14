using System;
using System.Collections.Generic;
using System.Text;

namespace BP.PriceTracker.Services.Types
{
    public record ImageSearchResultResponse
    {
        public string SkuId { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }
        public double Price { get; set; }
        public double? Discount { get; set; }
        public string? ProductName { get; set; }
    }
}
