using Microsoft.Extensions.DependencyInjection;

namespace DISample
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddWeatherForcastControllerOptions(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<WeatherForecastControllerOptions>();
            serviceCollection.ConfigureOptions<ConfigureWeatherForecastControllerOptions>();
            return serviceCollection;
        }
    }
}