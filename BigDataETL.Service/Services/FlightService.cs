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
        private Timer _timer;
        private bool _timerRunning = false; 
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

        public void StartDataFetchingTimer()
        {
            // Start a timer to fetch data every 5 minutes
            if (!_timerRunning)
            {
                _timer = new Timer(ProcessData, null, 0, 300000);
                _timerRunning = true;
            }
        }


        public async void ProcessData(Object state)
        {
            try
            {
                // Fetch data from the API and insert into repository
                var flights = await _flightAPIService.GetFlights();
                await _flightRepository.InsertData(_mappingService._mapper.Map<List<Flight>>(flights));
                await Console.Out.WriteLineAsync("Data was processed");
            }
            catch (Exception ex)
            {
                // Log and handle the exception
                await Console.Out.WriteLineAsync(ex.Message + "An error occoured");
            }
        }

        public async Task ProcessDataTest()
        {
            var flights = await _flightAPIService.GetFlights();
            await _flightRepository.InsertData(_mappingService._mapper.Map<List<Flight>>(flights));
            await Console.Out.WriteLineAsync("Data was processed");
        }

    }
}
