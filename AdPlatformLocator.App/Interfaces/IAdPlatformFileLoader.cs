using AdPlatformLocator.Domain.Models;

namespace AdPlatformLocator.App.Interfaces
{
    public interface IAdPlatformFileLoader
    {
        Task<IEnumerable<AdPlatform>> LoadAdPlatformsFromFileAsync(string filePath);
    }
}
