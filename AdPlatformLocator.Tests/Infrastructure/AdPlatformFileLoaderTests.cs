using AdPlatformLocator.Data;
using AdPlatformLocator.Domain.Models;

namespace AdPlatformLocator.Tests.Infrastructure
{
    public class AdPlatformFileLoaderTests
    {
        private readonly AdPlatformFileLoader _fileLoader;

        public AdPlatformFileLoaderTests()
        {
            _fileLoader = new AdPlatformFileLoader();
        }

        [Fact]
        public async Task LoadAdPlatformsFromFileAsyncValidFileShouldReturnAdPlatforms()
        {
            var filePath = "TestData.txt";
            var content = "Platform1: Location1, Location2\nPlatform2: Location3";
            await File.WriteAllTextAsync(filePath, content);

            var platforms = await _fileLoader.LoadAdPlatformsFromFileAsync(filePath);

            Assert.NotNull(platforms);
            Assert.Equal(2, platforms.Count());
            Assert.Contains(platforms, p => p.Name == "Platform1");
            Assert.Contains(platforms, p => p.Name == "Platform2");
        }

        [Fact]
        public async Task LoadAdPlatformsFromFileAsyncInvalidFormatShouldThrowFormatException()
        {
            var filePath = "InvalidTestData.txt";
            var content = "InvalidData";
            await File.WriteAllTextAsync(filePath, content);

            await Assert.ThrowsAsync<FormatException>(() => _fileLoader.LoadAdPlatformsFromFileAsync(filePath));
        }

        [Fact]
        public async Task LoadAdPlatformsFromFileAsyncMissingLocationsShouldThrowInvalidDataException()
        {
            var filePath = "MissingLocations.txt";
            var content = "Platform1: ";
            await File.WriteAllTextAsync(filePath, content);

            await Assert.ThrowsAsync<InvalidDataException>(() => _fileLoader.LoadAdPlatformsFromFileAsync(filePath));
        }
    }
}
