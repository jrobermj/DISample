using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Dependencies
{
    public class StringGetterWithLogging : StringGetter
    {
        private readonly ILogger _logger;
        public StringGetterWithLogging(IOptions<StringGetterGetterWithLoggingOptions> options) : base(options)
        {
            _logger = options.Value.Logger;
        }
        public override string GetString()
        {
            var s = base.GetString();
            _logger.LogInformation("I got string: {0}",s);
            return s;
        }
    }
}