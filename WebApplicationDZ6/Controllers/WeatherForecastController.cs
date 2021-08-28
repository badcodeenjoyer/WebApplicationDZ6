﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace WebApplicationDZ6.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        public IConfiguration Configuration { get; set; }

        public WeatherForecastController(ILogger<WeatherForecastController> logger , IConfiguration configuration)
        {
            _logger = logger;
            Configuration = configuration;
        }

        [HttpGet]
        [TypeFilter(typeof(Class))]
        [TypeFilter(typeof(FilterForException))]
        //https://localhost:5001/WeatherForecast for Postman
        public IEnumerable<WeatherForecast> Get()
        {
            
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                
                Summary = Summaries[rng.Next(Summaries.Length)]
                
            })
            .ToArray();
            
        }
    }
}
