using System;

namespace track_it.Entities
{
    public class Tracker
    {
        public string Id { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public DateTime LastPingUtc { get; set; }
    }
}
