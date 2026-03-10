using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;

namespace BP.PriceTracker.ViewModels;

public partial class HomeViewModel(ILogger<HomeViewModel> logger): ObservableObject
{
    [ObservableProperty]
    private bool isBusy;


    [RelayCommand]
    private async Task GoToFilter()
    {
        await Shell.Current.GoToAsync(Constants.Routes.CategoriesView);
    }


    [RelayCommand]
    private async Task Scan()
    {
        
    }

}
