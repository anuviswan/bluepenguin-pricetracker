using BP.PriceTracker.Services.Interfaces;
using Microsoft.Maui.Media;

namespace BP.PriceTracker.PlatformServices;

public class CameraService : ICameraService
{
    public async Task<Stream?> CapturePhotoAsync()
    {
        if (!MediaPicker.Default.IsCaptureSupported)
            return null;

        var photo = await MediaPicker.Default.CapturePhotoAsync();

        if (photo == null)
            return null;

        var stream = await photo.OpenReadAsync();

        var memory = new MemoryStream();
        await stream.CopyToAsync(memory);
        memory.Position = 0;

        return memory;
    }
}
