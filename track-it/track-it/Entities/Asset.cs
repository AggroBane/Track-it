namespace track_it.Entities
{
    public class Asset
    {
        public string Id { get; set; }
        public AssetType Type { get; set; }
        public string UserId { get; set; }
        public string ImageUrl { get; set; }
        public User User { get; set; }
        public string TrackerId { get; set; }
        public Tracker Tracker { get; set; }
    }
}
