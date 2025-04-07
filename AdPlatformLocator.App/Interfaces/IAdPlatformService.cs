using AdPlatformLocator.Domain.Models;

namespace AdPlatformLocator.App.Interfaces
{
    public interface IAdPlatformService
    {
        Task<LocationQueryResult> GetPlatformsByLocationAsync(string location);
        Task LoadAdPlatformsFromFileAsync(string filePath);
    }
}
