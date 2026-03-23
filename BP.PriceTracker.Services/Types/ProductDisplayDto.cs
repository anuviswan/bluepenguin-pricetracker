namespace BP.PriceTracker.Services.Types;

public record ProductDisplayDto
{
    public string Sku { get; init; } = string.Empty;
    public string ProductName { get; init; } = string.Empty;
    public string PrimaryImageUrl { get; init; } = string.Empty;

    public double Price { get; init; }
    public double DiscountPrice { get; init; }

}
