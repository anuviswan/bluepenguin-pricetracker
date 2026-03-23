namespace BP.PriceTracker.Services.Interfaces;

public interface ITokenService
{
    Task<string?> GetAuthTokenAsync();
    Task SetAuthTokenAsync(string token);
    Task ClearAsync();
}
