using BP.PriceTracker.Services.Interfaces;
using BP.PriceTracker.Services.Types;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.Logging;
using System.Collections.ObjectModel;

namespace BP.PriceTracker.ViewModels;

public partial class SearchResultViewModel : ObservableObject
{
    [ObservableProperty]
    private bool isBusy;

    [ObservableProperty]
    private ObservableCollection<ProductDto> products = new();
    
}
