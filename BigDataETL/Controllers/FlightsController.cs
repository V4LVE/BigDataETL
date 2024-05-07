using BigDataETL.Service.DTOs;
using BigDataETL.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace BigDataETL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FlightsController : ControllerBase
    {
      
        private readonly ILogger<FlightsController> _logger;
        private readonly ApiCaller _apiCaller;

        public FlightsController(ILogger<FlightsController> logger, ApiCaller apiCaller)
        {
            _logger = logger;
            _apiCaller = apiCaller;
        }

        [HttpGet(Name = "GetFligts")]
        public async Task Get()
        {
            List<Flight> flights = await _apiCaller.GetFlights();
        }
    }
}
