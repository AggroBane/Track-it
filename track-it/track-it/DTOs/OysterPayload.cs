using System.Collections.Generic;

namespace track_it.Entities
{
    public class OysterPayload
    {
        public int? SerNo { get; set; }
        public string IMEI { get; set; }
        public string ICCID { get; set; }
        public int? ProdId { get; set; }
        public string FW { get; set; }
        public List<Record> Records { get; set; }
        public class Record
        {
            public int? SeqNo { get; set; }
            public int? Reason { get; set; }
            public string DateUTC { get; set; }
            public List<Field> Fields { get; set; }
        }
        public class Field
        {
            public double? FType { get; set; }
            public string GpsUTC { get; set; }
            public double? Lat { get; set; }
            public double? Long { get; set; }
            public double? Alt { get; set; }
            public double? Spd { get; set; }
            public double? SpdAcc { get; set; }
            public double? Head { get; set; }
            public double? PDOP { get; set; }
            public double? PosAcc { get; set; }
            public double? GpsStat { get; set; }
            public double? Odo { get; set; }
            public double? RH { get; set; }
            public double? DIn { get; set; }
            public double? DOut { get; set; }
            public double? DevStat { get; set; }
            public double? DType { get; set; }
            public string Data { get; set; }
            public string DevAddr { get; set; }
            public string DevId { get; set; }
            public string MType { get; set; }
            public int[] Ms { get; set; }
            public double? TT { get; set; }
            public double? Trim { get; set; }
            public double? Dist { get; set; }
            public double? Dur { get; set; }

            public Dictionary<string, double?> AnalogueData { get; set; }
        }
    }
}
