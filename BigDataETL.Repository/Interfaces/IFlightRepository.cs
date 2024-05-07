using BigDataETL.Repository.Entites;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    

namespace BigDataETL.Repository.Interfaces
{
    public interface IFlightRepository : IGenericRepository<Flight>
    {
        /// <summary>
        /// Insert Data into the database
        /// </summary>
        /// <param name="flights"></param>
        /// <returns></returns>
        Task InsertData(List<Flight> flights);

    }
}
