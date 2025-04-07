using AdPlatformLocator.App.Interfaces;
using AdPlatformLocator.Domain.Models;

namespace AdPlatformLocator.Data
{
    public class AdPlatformFileLoader : IAdPlatformFileLoader
    {
        public async Task<IEnumerable<AdPlatform>> LoadAdPlatformsFromFileAsync(string filePath)
        {
            var lines = await File.ReadAllLinesAsync(filePath);
            var adPlatforms = new List<AdPlatform>();

            foreach (var line in lines) 
            {
                var parts = line.Split(':');
                var name = parts[0];
                var locations = parts[1].Split(',');

                adPlatforms.Add(new AdPlatform(name, locations));
            }

            return adPlatforms;
        }
    }
}
