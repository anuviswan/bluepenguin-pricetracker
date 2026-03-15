using BP.PriceTracker.Services.Interfaces;
using BP.PriceTracker.Services.Options;
using BP.PriceTracker.Services.Types;
using Microsoft.Extensions.Options;

namespace BP.PriceTracker.Services.Services;

public class ImageSearchService(IApiService apiService, IOptions<ApiSettings> apiOptions,ITokenService tokenService) : IImageSearchService
{
    private ApiSettings ApiSettings => apiOptions.Value;
    public async Task<ImageSearchResultResponse?> SearchByImage(Stream stream)
    {
        var endpoint = ApiSettings.SearchByImageEndpoint;
        var authToken = await tokenService.GetAuthTokenAsync();
        var response = await apiService.PostAsync<ImageSearchResultResponse>(endpoint, stream, "image.jpg",authToken).ConfigureAwait(false);
        return response.IsSuccess ? response.Data! : null;
    }
}
