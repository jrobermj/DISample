using System;
using System.Collections.Generic;
using Microsoft.Extensions.Options;

namespace Dependencies
{
    public class StringGetter : IStringGetter
    {
        private readonly List<string> _strings;
        private readonly Random _random;
        public StringGetter(IOptions<StringGetterOptions> options)
        {
            _strings = options.Value.PossibleStrings;
            _random = new Random();
        }
        public virtual string GetString()
        {
            var randomIndex = _random.Next(_strings.Count-1);
            return _strings[randomIndex];
        }
    }
}