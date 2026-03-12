using BP.PriceTracker.Services.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BP.PriceTracker.ViewModels;

[QueryProperty(nameof(ImageStream), nameof(ImageStream))]
public partial class ScanPreviewViewModel(IImageSearchService imageSearchService): ObservableObject
{
    private IImageSearchService ImageSearchService => imageSearchService;
    public Stream ImageStream { get; set; }

    public ImageSource PreviewImage => ImageSource.FromStream(() => ImageStream);


    [RelayCommand]
    public async Task Retake()
    {
        await Shell.Current.GoToAsync("..");
    }

    [RelayCommand]
    public async Task Confirm()
    {
        await ImageSearchService.SearchByImage(ImageStream);
    }
}
