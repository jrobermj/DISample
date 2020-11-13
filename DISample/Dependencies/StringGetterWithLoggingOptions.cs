using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;

namespace Dependencies
{
    public class StringGetterGetterWithLoggingOptions : StringGetterOptions
    {
        public ILogger Logger { get; set; }
    }

    public class ConfigureStringGetterWithLoggingOptions : IConfigureOptions<StringGetterGetterWithLoggingOptions>
    {
        private readonly ILogger _logger;
        private readonly IConfigureOptions<StringGetterOptions> _configureBaseOptions;
        
        public ConfigureStringGetterWithLoggingOptions(IServiceProvider serviceProvider)
        {
            var loggerFactory = serviceProvider.GetService<ILoggerFactory>() ?? new NullLoggerFactory();
            _logger = loggerFactory.CreateLogger<StringGetterWithLogging>();
            
            _configureBaseOptions = serviceProvider.GetService<IConfigureOptions<StringGetterOptions>>();
        }
        
        public void Configure(StringGetterGetterWithLoggingOptions options)
        {
            _configureBaseOptions?.Configure(options);
            options.Logger = _logger;
        }
    }
}