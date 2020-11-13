using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dependencies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DISample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IStringGetter _summaryGetter;

        private readonly ILogger _logger;

        public WeatherForecastController(IOptions<WeatherForecastControllerOptions> options)
        {
            _logger = options.Value.Logger;
            _summaryGetter = options.Value.StringGetter;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = _summaryGetter.GetString()
                })
                .ToArray();
        }
    }
}