namespace AdPlatformLocator.Domain.Models
{
    public class AdPlatform
    {
        public string Name { get; set; }
        public List<string> Locations { get; set; } = new List<string>();

        public AdPlatform(string name, IEnumerable<string> locations)
        {
            Name = name;
            Locations.AddRange(locations);
        }
    }
}
