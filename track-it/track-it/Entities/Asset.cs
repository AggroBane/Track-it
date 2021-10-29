namespace track_it.Entities
{
    public class Asset
    {
        public string Name { get; set; }
        public AssetType Type { get; set; }
        public User User { get; set; }
        public Tracker Tracker { get; set; }
    }
}
