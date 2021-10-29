using System;

namespace track_it.Entities
{
    public class Tracker
    {
        public string Id { get; set; }
        public float Lat { get; set; }
        public float Lng { get; set; }
        public DateTime LastPingUtc { get; set; }
    }
}
