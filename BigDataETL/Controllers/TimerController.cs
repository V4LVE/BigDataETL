﻿using BigDataETL.Controllers;
using BigDataETL.Service.API;
using BigDataETL.Service.DTOs;
using BigDataETL.Service.Interfaces;
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
        private Timer timer;

        public event EventHandler<List<FlightDTO>> OnDataProcessed;
        private CancellationTokenSource cancellationTokenSource;

        public TimerController(ILogger<FlightsController> logger, IFlightService flightService)
        {
            _logger = logger;
            _flightService = flightService;
        }

        [HttpPost]
        [Route("StartTimer")]
        public async Task<IActionResult> StartTimer()
        {
            if (timer == null)
            {
                cancellationTokenSource = new CancellationTokenSource();
                timer = new Timer(async _ =>
                {
                    try
                    {
                        var response = await _flightService.ProcessData();
                        OnDataProcessed?.Invoke(this, response);
                    }
                    catch (OperationCanceledException)
                    {
                        Console.WriteLine("API call timed out.");
                    }
                }, null, 0, 300000);
                return Ok("Timer started");
                
            }
            else
            {
                return BadRequest("Timer is already running");
            }
            
        }

       
    }
}