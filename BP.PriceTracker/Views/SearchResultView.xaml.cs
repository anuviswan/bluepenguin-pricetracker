using BP.PriceTracker.Services.Types;
using BP.PriceTracker.ViewModels;

namespace BP.PriceTracker.Views;

public partial class SearchResultView : ContentPage
{
	public SearchResultView(SearchResultViewModel model)
	{
		InitializeComponent();
		BindingContext = model;
	}

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.TryGetValue(nameof(SearchResultViewModel.Products), out var products))
        {
            ((SearchResultViewModel)BindingContext).Products = new System.Collections.ObjectModel.ObservableCollection<ProductDto>((IEnumerable<ProductDto>)products);
        }
    }
}