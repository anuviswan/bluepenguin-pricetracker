using BP.PriceTracker.Services.Interfaces;

namespace BP.PriceTracker.PlatformServices;

public class TokenService : ITokenService
{
    private const string TokenKey = "auth_token";

    public async Task<string?> GetAuthTokenAsync()
    {
        return await SecureStorage.GetAsync(TokenKey);
    }

    public async Task SetAuthTokenAsync(string token)
    {
        await SecureStorage.SetAsync(TokenKey, token);
    }

    public Task ClearAsync()
    {
        SecureStorage.Remove(TokenKey);
        return Task.CompletedTask;
    }
}
