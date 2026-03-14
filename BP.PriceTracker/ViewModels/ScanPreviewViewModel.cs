using BP.PriceTracker.Services.Interfaces;
using BP.PriceTracker.Services.Types;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BP.PriceTracker.ViewModels;

//[QueryProperty(nameof(ImageStream), nameof(ImageStream))]
public partial class ScanPreviewViewModel(IImageSearchService imageSearchService): ObservableObject
{
    private IImageSearchService ImageSearchService => imageSearchService;
    public Stream ImageStream
    {
        get => field;
        set
        {
            field = value;
            OnPropertyChanged(nameof(PreviewImage));
        }
    }

    public ImageSource? PreviewImage => ImageStream == null ? null : ImageSource.FromStream(() => ImageStream);


    [RelayCommand]
    public async Task Retake()
    {
        await Shell.Current.GoToAsync("..");
    }

    [RelayCommand]
    public async Task Confirm()
    {
        var results = await ImageSearchService.SearchByImage(ImageStream).ConfigureAwait(false);
    }
}
