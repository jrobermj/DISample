using Microsoft.Extensions.DependencyInjection;

namespace Dependencies
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddStringGetter(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<StringGetterOptions>();
            serviceCollection.ConfigureOptions<ConfigureStringGetterOptions>();
            serviceCollection.AddSingleton<IStringGetter, StringGetter>();
            return serviceCollection;
        }
        
        public static IServiceCollection AddStringGetterWithLogging(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<StringGetterGetterWithLoggingOptions>();
            serviceCollection.ConfigureOptions<ConfigureStringGetterWithLoggingOptions>();
            serviceCollection.ConfigureOptions<ConfigureStringGetterOptions>();
            serviceCollection.AddSingleton<IStringGetter, StringGetterWithLogging>();
            return serviceCollection;
        }
    }
}