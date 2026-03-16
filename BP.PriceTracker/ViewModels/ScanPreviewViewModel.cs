using BP.PriceTracker.Services.Interfaces;
using BP.PriceTracker.Services.Types;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BP.PriceTracker.ViewModels;

//[QueryProperty(nameof(ImageStream), nameof(ImageStream))]
public partial class ScanPreviewViewModel(IImageSearchService imageSearchService): ObservableObject
{
    private IImageSearchService ImageSearchService => imageSearchService;
    private byte[]? _imageBytes;

    public Stream ImageStream
    {
        get => new MemoryStream(_imageBytes!);
        set
        {
            using var ms = new MemoryStream();
            value.CopyTo(ms);
            _imageBytes = ms.ToArray();

            OnPropertyChanged(nameof(PreviewImage));
        }
    }

    public ImageSource? PreviewImage =>    _imageBytes == null ? null: ImageSource.FromStream(() => new MemoryStream(_imageBytes));


    [RelayCommand]
    public async Task Retake()
    {
        await Shell.Current.GoToAsync("..");
    }

    [RelayCommand]
    public async Task Confirm()
    {
        var stream = new MemoryStream(_imageBytes!);
        var results = await ImageSearchService.SearchByImage(stream);
    }
}
