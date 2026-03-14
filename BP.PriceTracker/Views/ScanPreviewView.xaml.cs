using BP.PriceTracker.ViewModels;

namespace BP.PriceTracker.Views;

public partial class ScanPreviewView : ContentPage, IQueryAttributable
{
	public ScanPreviewView(ScanPreviewViewModel model)
	{
		InitializeComponent();
        BindingContext = model;
	}

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.TryGetValue(nameof(ScanPreviewViewModel.ImageStream), out var stream))
        {
            ((ScanPreviewViewModel)BindingContext).ImageStream = (Stream)stream;
        }
    }
}