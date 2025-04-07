namespace AdPlatformLocator.Domain.Models
{
    public class LocationQueryResult
    {
        public string Location { get; set; }
        public List<AdPlatform> AdPlatforms { get; set; } = new List<AdPlatform>();

        public LocationQueryResult(string location)
        {
            Location = location;
        }
    }
}
