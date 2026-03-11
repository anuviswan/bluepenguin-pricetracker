using BP.PriceTracker.ViewModels;

namespace BP.PriceTracker.Views;

public partial class CategoryView : ContentPage
{
	public CategoryView(CategoryViewModel model)
	{
        InitializeComponent();
        BindingContext = model;
    }
}