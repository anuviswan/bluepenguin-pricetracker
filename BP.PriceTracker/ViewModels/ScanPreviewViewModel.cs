using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BP.PriceTracker.ViewModels;

[QueryProperty(nameof(ImageStream), nameof(ImageStream))]
public partial class ScanPreviewViewModel: ObservableObject
{
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

    }
}
