using Microsoft.Extensions.Logging;
using WeatherApi.Models;
using WeatherApi.Models.Dtos;

namespace WeatherApi.Services;

/// <summary>
/// Represents a weather service.
/// </summary>
/// <param name="httpClient">the HTTP client</param>
/// <param name="config">the configuration</param>
/// <param name="logger">the logger</param>
public class WeatherService(HttpClient httpClient, IConfiguration config, ILogger<WeatherService> logger)
    : IWeatherService
{
    private readonly HttpClient _httpClient = httpClient;
    private readonly ILogger<WeatherService> _logger = logger;
    private readonly string _apiKey
        = config["OpenWeather:ApiKey"] ?? throw new ArgumentNullException("API key not configured.");

    /// <inheritdoc/>
    public async Task<Weather> GetWeather(double lat, double lon, string[] excludeArray)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(lat);
            ArgumentNullException.ThrowIfNull(lon);

            string excludeParts = string.Join(',', excludeArray);

            var url = $"https://api.openweathermap.org/data/3.0/onecall?lat={lat}&lon={lon}" +
                    $"&exclude={excludeParts}&appid={_apiKey}&units=metric";

            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"OpenWeather error: {response.StatusCode}");
            }

            OpenWeatherDto? openWeatherDto = await response.Content.ReadFromJsonAsync<OpenWeatherDto>();

            if (openWeatherDto is null)
            {
                throw new InvalidOperationException("Could not parse weather data from OpenWeather response.");
            }

            Weather result = WeatherConversions.ConvertWeather(openWeatherDto);

            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unexpected error while retrieving weather data.");

            throw;
        }
    }
}
