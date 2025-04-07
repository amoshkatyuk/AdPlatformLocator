using AdPlatformLocator.App.Interfaces;
using AdPlatformLocator.Domain.Models;

namespace AdPlatformLocator.Data.Storages
{
    public class InMemoryAdPlatformStorage : IAdPlatformStorage
    {
        private List<AdPlatform> _adPlatforms = new List<AdPlatform>();

        public Task<IEnumerable<AdPlatform>> GetAllAdPlatformsAsync()
        {
            return Task.FromResult<IEnumerable<AdPlatform>>(_adPlatforms);
        }

        public Task SaveAdPlatformAsync(IEnumerable<AdPlatform> adPlatforms)
        {
            _adPlatforms = adPlatforms.ToList();
            return Task.CompletedTask;
        }
    }
}
