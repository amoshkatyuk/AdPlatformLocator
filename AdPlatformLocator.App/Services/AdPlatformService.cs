using AdPlatformLocator.App.Interfaces;
using AdPlatformLocator.Domain.Models;

namespace AdPlatformLocator.App.Services
{
    public class AdPlatformService : IAdPlatformService
    {
        private readonly IAdPlatformStorage _adPlatformStorage;
        private readonly IAdPlatformFileLoader _adPlatformFileLoader;

        public AdPlatformService(IAdPlatformStorage adPlatformStorage, IAdPlatformFileLoader adPlatformFileLoader)
        {
            _adPlatformStorage = adPlatformStorage;
            _adPlatformFileLoader = adPlatformFileLoader;
        }

        public async Task<LocationQueryResult> GetPlatformsByLocationAsync(string location)
        {
            var allPlatforms = await _adPlatformStorage.GetAllAdPlatformsAsync();
            var result = new LocationQueryResult(location);

            foreach (var platform in allPlatforms) 
            {
                if (platform.Locations.Any(loc => loc.StartsWith(location))) 
                {
                    result.AdPlatforms.Add(platform);
                }
            }

            return result;
        }

        public async Task LoadAdPlatformsFromFileAsync(string filePath)
        {
            var adPlatforms = await _adPlatformFileLoader.LoadAdPlatformsFromFileAsync(filePath);
            await _adPlatformStorage.SaveAdPlatformAsync(adPlatforms);
        }
    }
}
