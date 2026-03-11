namespace BP.PriceTracker.Services.Interfaces;

public interface ICameraService
{
    Task<Stream?> CapturePhotoAsync();
}
