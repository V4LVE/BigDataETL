using BigDataETL.Controllers;
using BigDataETL.Service.API;
using BigDataETL.Service.DTOs;
using BigDataETL.Service.Interfaces;
using BigDataETL.Service.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;

namespace BigDataETL.WebService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TimerController : ControllerBase
    {

        private readonly ILogger<FlightsController> _logger;
        private readonly IFlightService _flightService;


        public TimerController(ILogger<FlightsController> logger, IFlightService flightService)
        {
            _logger = logger;
            _flightService = flightService;
        }

        [HttpPost]
        [Route("Test")]
        public async Task<IActionResult> StartTest()
        {
            _flightService.StartDataFetchingTimer();
            return Ok();

        }

        [HttpPost]
        [Route("TestLoop")]
        public async Task<IActionResult> StopTimer()
        {
            while (true)
            {
                await _flightService.ProcessDataTest();
                await Task.Delay(100000);
            }
        }
        //[HttpPost]
        //[Route("StartTimer")]
        //public async Task<IActionResult> StartTimer()
        //{
        //    if (timer == null)
        //    {
        //        using (var scope = this._serviceProvider.CreateScope())
        //        {
        //            cancellationTokenSource = new CancellationTokenSource();
        //            timer = new Timer(async _ =>
        //            {
        //                try
        //                {
        //                    var response = await _flightService.ProcessData();
        //                    OnDataProcessed?.Invoke(this, response);
        //                }
        //                catch (OperationCanceledException)
        //                {
        //                    Console.WriteLine("API call timed out.");
        //                }
        //            }, null, 0, 300000);
        //            return Ok("Timer started");
        //        }
        //    }
        //    else
        //    {
        //        return BadRequest("Timer is already running");
        //    }
            
        //}

       
    }
}
