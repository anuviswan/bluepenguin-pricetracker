namespace BP.PriceTracker.Services.Interfaces;

public interface IImageSearchService
{
    Task SearchByImage(Stream stream);
}
