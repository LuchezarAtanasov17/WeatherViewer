using WeatherApi.Models;
using WeatherApi.Models.Dtos;

namespace WeatherApi.Services;

/// <summary>
/// Represents a weather service.
/// </summary>
/// <param name="httpClient">the HTTP client</param>
/// <param name="config">the configuration</param>
public class WeatherService(HttpClient httpClient, IConfiguration config)
    : IWeatherService
{
    private readonly HttpClient _httpClient = httpClient;
    private readonly string _apiKey
        = config["OpenWeather:ApiKey"] ?? throw new ArgumentNullException("API key not configured.");

    /// <inheritdoc/>
    public async Task<Weather> GetWeather(double lat, double lon, string[] excludeArray)
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

        ArgumentNullException.ThrowIfNull(openWeatherDto);

        var weather = new Weather
        {
            Temperature = openWeatherDto.current?.temp ?? 0,
            Description = openWeatherDto.current?.weather?[0].description ?? "",
            Icon = openWeatherDto.current?.weather?[0].icon ?? "",
            Humidity = openWeatherDto.current?.humidity ?? 0,
            WindSpeed = openWeatherDto.current?.wind_speed ?? 0,
            Timezone = openWeatherDto.timezone ?? "",
        };

        return weather;
    }
}
