using BigDataETL.Repository.Entites;
using BigDataETL.Repository.Interfaces;
using BigDataETL.Service.DTOs;
using BigDataETL.Service.Interfaces;
using LinqLangProjekt.Utility;
using System.Security.Cryptography;
using System.Text.Json;

namespace BigDataETL.Service.API
{
    public class FlightAPIService : FlightsRestClient
    {
     
        public async Task<List<FlightDTO>> GetFlights()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

            string endpoint = "states/all?lamin=54.963435&lomin=8.275856&lamax=57.817087&lomax=10.870537";
            var flights = await CallEndpointAsync<FlightsModelDTO>(endpoint);
            var temp = flights.states.Select(f => new FlightDTO
            {
                Icao24 = f[0].ToString(),
                Callsign = f[1]?.ToString(),
                Origin_country = f[2].ToString(),
                Time_position = Convert.ToInt32(f[3].ToString()),
                Last_contact = Convert.ToInt32(f[4].ToString()),
                Longitude = Convert.ToDouble(f[5]?.ToString()),
                Latitude = Convert.ToDouble(f[6]?.ToString()),
                Baro_altitude = Convert.ToDouble(f[7]?.ToString()),
                On_ground = Convert.ToBoolean(f[8]?.ToString()),
                Velocity = Convert.ToDouble(f[9]?.ToString()),
                True_track = Convert.ToDouble(f[10]?.ToString()),
                Vertical_rate = Convert.ToDouble(f[11]?.ToString()),
                Sensors = f[12] == null ? null : f[12]?.ToString().Split(',').Select(s => Convert.ToInt32(s.ToString())).ToArray(),
                Geo_altitude = Convert.ToDouble(f[13]?.ToString()),
                Squawk = f[14] == null ? null : f[14]?.ToString(),
                Spi = Convert.ToBoolean(f[15]?.ToString()),
                Position_source = Convert.ToInt32(f[16]?.ToString())
            }).ToList();

            return temp;
        }
    }
}
