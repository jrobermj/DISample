using System;
using Dependencies;
using DISample.Controllers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;

namespace DISample
{
    public class WeatherForecastControllerOptions
    {
        public IStringGetter StringGetter { get; set; }
        public ILogger Logger { get; set; }
    }

    public class ConfigureWeatherForecastControllerOptions : IConfigureOptions<WeatherForecastControllerOptions>
    {
        private readonly IStringGetter _stringGetter;
        private readonly ILogger _logger;

        public ConfigureWeatherForecastControllerOptions(IServiceProvider serviceProvider)
        {
            _stringGetter = serviceProvider.GetRequiredService<IStringGetter>();
            var loggerFactory = serviceProvider.GetService<ILoggerFactory>() ?? new NullLoggerFactory();
            _logger = loggerFactory.CreateLogger<WeatherForecastController>();
        }
        
        public void Configure(WeatherForecastControllerOptions options)
        {
            options.Logger = _logger;
            options.StringGetter = _stringGetter;
        }
    }
}