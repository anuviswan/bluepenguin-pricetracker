using BP.PriceTracker.Services.Interfaces;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;
using System.Collections.ObjectModel;

namespace BP.PriceTracker.ViewModels;

public partial class HomeViewModel(ILogger<HomeViewModel> logger): ObservableObject
{
    [ObservableProperty]
    private bool isBusy;


    [RelayCommand]
    private async Task Filter()
    {
        await Shell.Current.GoToAsync(Constants.Routes.CategoriesView);
    }


    [RelayCommand]
    private async Task Scan()
    {
        
    }

}
