namespace BigDataETL.Models
{
    public class Flight
    {
        public string icao24 { get; set; }
        public string callsign { get; set; }
        public string origin_country { get; set; }
        public int time_position { get; set; }
        public int last_contact { get; set; }
        public double longitude { get; set; }
        public double latitude { get; set; }
        public double baro_altitude { get; set; }
        public bool on_ground { get; set; }
        public double velocity { get; set; }
        public double true_track { get; set; }
        public double vertical_rate { get; set; }
        public object sensors { get; set; }
        public double geo_altitude { get; set; }
        public object squawk { get; set; }
        public bool spi { get; set; }
        public int position_source { get; set; }

    }
}
