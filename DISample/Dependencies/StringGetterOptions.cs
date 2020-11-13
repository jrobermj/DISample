using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;

namespace Dependencies
{
    public class StringGetterOptions
    {
        public List<String> PossibleStrings { get; set; }
    }

    public class ConfigureStringGetterOptions : IConfigureOptions<StringGetterOptions>
    {
        private readonly List<string> _strings;
        public ConfigureStringGetterOptions(IServiceProvider serviceProvider)
        {
            _strings = serviceProvider.GetRequiredService<IConfiguration>().GetSection("possibleStrings")
                .Get<List<string>>();
        }
        
        public void Configure(StringGetterOptions getterOptions)
        {
            getterOptions.PossibleStrings = _strings;
        }
    }
}