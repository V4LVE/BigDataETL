using BigDataETL.Repository.Entites;
using BigDataETL.Repository.Interfaces;
using BigDataETL.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BigDataETL.Service.Interfaces
{
    public interface IFlightService : IGenericRepository<FlightDTO>
    {
        /// <summary>
        /// Insert Data into the database
        /// </summary>
        /// <param name="flights"></param>
        /// <returns></returns>
        Task InsertData(List<FlightDTO> flights);

        /// <summary>
        /// Start Data Fetching Timer
        /// </summary>
        public void StartDataFetchingTimer();

        /// <summary>
        /// Proess Data
        /// </summary>
        /// <returns></returns>
        void ProcessData(Object state);

        Task ProcessDataTest();
    }
}
