using WeatherApi.Models;
using WeatherApi.Models.Dtos;

namespace WeatherApi.Services;

/// <summary>
/// Contains methods for converting weather models between Dtos and service types.
/// </summary>
internal static class WeatherConversions
{
    /// <summary>
    /// Converts an open weather Dto to service type.
    /// </summary>
    /// <param name="source">the source</param>
    /// <returns>the converted weather</returns>
    public static Weather ConvertWeather(OpenWeatherDto source)
    {
        ArgumentNullException.ThrowIfNull(source);

        var target = new Weather
        {
            Temperature = source.current?.temp ?? 0,
            Description = source.current?.weather?[0].description ?? "",
            Icon = source.current?.weather?[0].icon ?? "",
            Humidity = source.current?.humidity ?? 0,
            WindSpeed = source.current?.wind_speed ?? 0,
            Timezone = source.timezone ?? "",
        };

        return target;
    }
}
