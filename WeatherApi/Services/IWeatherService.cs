using WeatherApi.Models;

namespace WeatherApi.Services;

/// <summary>
/// Represents a service for managing weather.
/// </summary>
public interface IWeatherService
{
    /// <summary>
    /// Gets a weather information.
    /// </summary>
    /// <param name="latitude">the latitude</param>
    /// <param name="longitude">the longitude</param>
    /// <param name="excludeArray">the exclude array</param>
    /// <returns>the weather</returns>
   Task<Weather> GetWeather(double latitude, double longitude, string[] excludeArray);
}
