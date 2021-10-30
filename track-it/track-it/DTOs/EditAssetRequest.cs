using track_it.Entities;

namespace track_it.DTOs
{
    public class EditAssetRequest
    {
        public AssetType? Type { get; set; }
        public string UserId { get; set; }
        public string ImageUrl { get; set; }
        public string TrackerId { get; set; }
    }
}
