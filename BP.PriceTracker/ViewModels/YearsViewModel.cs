using BP.PriceTracker.Services.Interfaces;
using BP.PriceTracker.Services.Services;
using BP.PriceTracker.Services.Types;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;
using System.Collections.ObjectModel;

namespace BP.PriceTracker.ViewModels;

public partial class YearsViewModel(INavigationCacheService cacheService, IProductService productService, ILogger<YearsViewModel> logger):ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<TagItemEntry> tags = [];

    [ObservableProperty]
    private bool isBusy;

    [RelayCommand]
    private async Task LoadDataAsync()
    {
        if (IsBusy)
            return;
        try
        {
            IsBusy = true;
            var collections = Enumerable.Range(2023, (DateTime.Today.Year - 2023) + 1).Select(x=> new TagItemEntry(x.ToString(), x.ToString(), false)).ToList();
            Tags = new ObservableCollection<TagItemEntry>(collections);
        }
        catch (Exception e)
        {
            IsBusy = false;
            logger.LogError("Failed to load Year List {0}", e.Message);
            await Snackbar.Make("Unable to retrieve Year list", async () => await LoadDataAsync(), "Retry", new TimeSpan(0, 0, 5)).Show();
        }
        finally
        {
            IsBusy = false;
        }

    }

    [RelayCommand]
    private async Task MoveNext()
    {
        cacheService.Add<IEnumerable<TagItemEntry>>("SelectedYears", Tags.Where(t => t.IsSelected));
        var products = await LoadProductDetailsAsync().ConfigureAwait(false);
        await Shell.Current.GoToAsync(Constants.Routes.SearchListView, new Dictionary<string, object>
                    {
                        { "Results", products }
                    });
    }


    private async Task<IEnumerable<ProductDto>> LoadProductDetailsAsync()
    {
        // Read selected filters from navigation cache
        var selectedCategories = cacheService.Get<IEnumerable<TagItemEntry>>("SelectedCategories")?.Select(t => t.Id) ?? Enumerable.Empty<string>();
        var selectedMaterials = cacheService.Get<IEnumerable<TagItemEntry>>("SelectedMaterials")?.Select(t => t.Id) ?? Enumerable.Empty<string>();
        var selectedCollections = cacheService.Get<IEnumerable<TagItemEntry>>("SelectedCollections")?.Select(t => t.Id) ?? Enumerable.Empty<string>();
        var selectedFeatures = cacheService.Get<IEnumerable<TagItemEntry>>("SelectedFeatures")?.Select(t => t.Id) ?? Enumerable.Empty<string>();
        var selectedYears = cacheService.Get<IEnumerable<TagItemEntry>>("SelectedYears")?.Select(t => t.Id) ?? Enumerable.Empty<string>();

        var filters = new SearchFilter
        {
            Categories = selectedCategories.ToArray(),
            Materials = selectedMaterials.ToArray(),
            Collections = selectedCollections.ToArray(),
            Features = selectedFeatures.ToArray(),
            YearCodes = selectedYears.ToArray()
        };

        return await productService.SearchProductsAsync(filters);

    }
}
