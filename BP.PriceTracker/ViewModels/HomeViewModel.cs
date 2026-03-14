using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Media;

namespace BP.PriceTracker.ViewModels;

public partial class HomeViewModel(ILogger<HomeViewModel> logger): ObservableObject
{
    [ObservableProperty]
    private bool isBusy;

    private ILogger<HomeViewModel> Logger => logger;


    [RelayCommand]
    private async Task GoToFilter()
    {
        await Shell.Current.GoToAsync(Constants.Routes.CategoriesView);
    }


    [RelayCommand]
    private async Task Scan()
    {
        try
        {
            Logger.LogInformation("Check camera availabaility");
            if (MediaPicker.Default.IsCaptureSupported)
            {
                Logger.LogInformation("Camera is available, opening camera");
                var photo = await MediaPicker.Default.CapturePhotoAsync();
                if (photo != null)
                {
                    Logger.LogInformation("Photo captured successfully: {FileName}", photo.FileName);
                    // Handle the captured photo as needed, pass to Preview View Model
                    await Shell.Current.GoToAsync(Constants.Routes.ScanPreviewView, new Dictionary<string, object>
                    {
                        { nameof(ScanPreviewViewModel.ImageStream), await photo.OpenReadAsync() }
                    });
                }
                else
                {
                    Logger.LogWarning("Photo capture was canceled by the user.");
                }
            }

        }
        catch (Exception)
        {

            throw;
        }
    }

}
