using track_it.Entities;

namespace track_it.DTOs
{
    public class CreateAssetRequest
    {
        public string Id { get; set; }
        public AssetType Type { get; set; }
        public string UserId { get; set; }
        public string ImageUrl { get; set; }
        public string TrackerId { get; set; }
    }
}
