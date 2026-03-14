using BP.PriceTracker.Services.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Maui.Alerts;
using Microsoft.Extensions.Logging;

namespace BP.PriceTracker.ViewModels;

public partial class LoginViewModel(ILogger<LoginViewModel> logger, IUserService userService) : ObservableObject
{

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(ExecuteLoginCommand))]
    private string? passKey;

    [ObservableProperty]
    private bool isBusy;

    [RelayCommand(CanExecute = nameof(CanExecuteLogin))]
    private async Task ExecuteLogin()
    {
        IsBusy = true;
        var response = await userService.ValidateUser(PassKey!).ConfigureAwait(false);

        if (response?.IsAuthenticated == true)
        {
            IsBusy = false;
            await SecureStorage.SetAsync("auth_token", response.AuthToken).ConfigureAwait(false);
            await Shell.Current.GoToAsync(Constants.Routes.HomeView).ConfigureAwait(false);
        }
        else
        {
            IsBusy = false;
            await Toast.Make("Invalid PassKey").Show();
        }
        
    }

    public bool CanExecuteLogin()
    {
        return !string.IsNullOrWhiteSpace(PassKey);
    }
}
