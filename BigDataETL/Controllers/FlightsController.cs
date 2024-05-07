using BigDataETL.Service.API;
using BigDataETL.Service.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BigDataETL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FlightsController : ControllerBase
    {
      
        private readonly ILogger<FlightsController> _logger;
        private readonly FlightAPIService _apiCaller;

        public FlightsController(ILogger<FlightsController> logger, FlightAPIService apiCaller)
        {
            _logger = logger;
            _apiCaller = apiCaller;
        }

        [HttpGet(Name = "GetFligts")]
        public async Task Get()
        {
            List<FlightDTO> flights = await _apiCaller.GetFlights();
        }
    }
}
