using BigDataETL.Repository.Entites;
using BigDataETL.Repository.Interfaces;
using BigDataETL.Service.API;
using BigDataETL.Service.DTOs;
using BigDataETL.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
        public Timer? Timer { get; set; }
        public bool TimerRunning { get; set; } = false;
        public List<double> ExecutionTimes { get; set; } = new();
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

        public string StartDataFetchingTimer()
        {
           
            // Start a timer to fetch data every 5 minutes
            if (!TimerRunning)
            {;
                
                Timer = new Timer(ProcessData, null, 0, 300000);
               
                TimerRunning = true;
                return "Timer Started";
            }
            else
            {
                return "Timer already running";
            }
        }

        public string StopDataFetchingTimer()
        {
            // Stop the data fetching timer
            if (TimerRunning)
            {
                Timer?.Dispose();
                TimerRunning = false;
                string response = "Timer Stopped";
                response += Environment.NewLine + $"Average Execution time: {ExecutionTimes.Average()}";
                response += Environment.NewLine + "Execution Times:";
                foreach (var time in ExecutionTimes)
                {
                    response +=  Environment.NewLine + time.ToString();
                }
                ExecutionTimes.Clear();
                return response;
            }
            else
            {
                return "No timer is running";
            }
           
        }
        


        public async void ProcessData(Object state)
        {
            Stopwatch stopwatch = new();
            try
            {
                stopwatch.Start();
                // Fetch data from the API and insert into repository
                var flights = await _flightAPIService.GetFlights();
                await _flightRepository.InsertData(_mappingService._mapper.Map<List<Flight>>(flights));
                stopwatch.Stop();
                ExecutionTimes.Add(stopwatch.Elapsed.TotalSeconds);
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
