namespace BigDataETL.Models
{
    public class Flight
    {
        public string? Icao24 { get; set; }
        public string? Callsign { get; set; }
        public string? Origin_country { get; set; }
        public int? Time_position { get; set; }
        public int? Last_contact { get; set; }
        public double? Longitude { get; set; }
        public double? Latitude { get; set; }
        public double? Baro_altitude { get; set; }
        public bool? On_ground { get; set; }
        public double? Velocity { get; set; }
        public double? True_track { get; set; }
        public double? Vertical_rate { get; set; }
        public int[]? Sensors { get; set; }
        public double? Geo_altitude { get; set; }
        public string? Squawk { get; set; }
        public bool? Spi { get; set; }
        public int? Position_source { get; set; }

    }
}
