using BP.PriceTracker.Services.Types;

namespace BP.PriceTracker.Services.Interfaces;

public interface IImageSearchService
{
    Task<ImageSearchResultResponse?> SearchByImage(Stream stream);
}
