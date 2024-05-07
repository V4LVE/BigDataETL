using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using Microsoft.Data.SqlClient;
using BigDataETL.Repository.Repositories;
using BigDataETL.Repository.Entites;
using BigDataETL.Repository.Interfaces;
using BigDataETL.Repository.Domain;

namespace ToDoList.Repository.Repositories
{
    public class FlightRepository : GenericRepository<Flight>, IFlightRepository
    {
        #region Backing fields
        private readonly BigDataContext _dbContext;
        #endregion

        #region Constructor
        public FlightRepository(BigDataContext context) : base(context)
        {
            _dbContext = context;
        }
        #endregion

        public async Task InsertData(List<Flight> flights)
        {
            List<Flight> insertFlights = new();
            foreach (var flight in flights)
            {
                var flightExists = await _dbContext.Flights.FirstOrDefaultAsync(f => f.Callsign == flight.Callsign && f.Icao24 == flight.Icao24);


                if (flightExists != null)
                {
                    var flightHascode = flight.Time_position + flight.Longitude + flight.Last_contact + flight.Latitude + flight.Baro_altitude + flight.Velocity;
                    var flightExistsHascode = flightExists.Time_position + flightExists.Longitude + flightExists.Last_contact + flightExists.Latitude + flightExists.Baro_altitude + flightExists.Velocity;

                    if (flightHascode != flightExistsHascode)
                    {
                        insertFlights.Add(flight);
                    }
                }
                else
                {
                    insertFlights.Add(flight);
                }
            }

            if (insertFlights.Count > 0)
            {
                await _dbContext.Flights.AddRangeAsync(insertFlights);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
