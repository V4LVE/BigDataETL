using BigDataETL.Repository.Entites;
using BigDataETL.Repository.Interfaces;
using BigDataETL.Service.API;
using BigDataETL.Service.DTOs;
using BigDataETL.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BigDataETL.Service.Services
{
    public class FlightService : GenericService<FlightDTO, IFlightRepository, Flight>, IFlightService
    {
        #region backing fields
        private readonly MappingService _mappingService;
        private readonly IFlightRepository _flightRepository;
        private readonly FlightAPIService _flightAPIService;
        #endregion

        #region Constructor
        public FlightService(MappingService mappingService, IFlightRepository flightRepository, FlightAPIService flightAPIService) : base(mappingService,flightRepository)
        {
            _mappingService = mappingService;
            _flightRepository = flightRepository;
            _flightAPIService = flightAPIService;
        }
        #endregion

        /// <summary>
        /// Insert Data into the database
        /// </summary>
        /// <param name="flights"></param>
        /// <returns></returns>
        public async Task InsertData(List<FlightDTO> flights)
        {
            await _flightRepository.InsertData(_mappingService._mapper.Map<List<Flight>>(flights));
        }

        public async Task<List<FlightDTO>> ProcessData()
        {
            var flights = await _flightAPIService.GetFlights();
            await InsertData(flights);
            await Console.Out.WriteLineAsync("Data was processed");
            return flights;
        }

    }
}
