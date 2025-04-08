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
                if (parts.Length != 2) 
                {
                    throw new FormatException($"Invalid format in line: {line}");
                }

                var name = parts[0].Trim();
                var locations = parts[1].Split(',').Select(loc => loc.Trim()).ToList();

                if (!locations.Any() || locations.All(string.IsNullOrWhiteSpace))
                {
                    throw new InvalidDataException($"No valid locations found for platform '{name}'");
                }

                if (locations.Count == 0)
                {
                    throw new Exception($"No locations found for platform: {name}");
                }

                adPlatforms.Add(new AdPlatform(name, locations));
            }

            return adPlatforms;
        }
    }
}
