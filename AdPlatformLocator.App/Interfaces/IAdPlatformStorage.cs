using AdPlatformLocator.Domain.Models;

namespace AdPlatformLocator.App.Interfaces
{
    public interface IAdPlatformStorage
    {
        Task<IEnumerable<AdPlatform>> GetAllAdPlatformsAsync();
        Task SaveAdPlatformAsync(IEnumerable<AdPlatform> adPlatforms);
    }
}
