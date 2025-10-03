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
    public async Task<Weather> GetWeather(double lat, double lon)
    {
        ArgumentNullException.ThrowIfNull(lat);
        ArgumentNullException.ThrowIfNull(lon);

        var url = $"https://api.openweathermap.org/data/3.0/onecall?lat=42.6977&lon=23.3219&exclude=minutely,hourly,daily,alerts&units=metric&appid={_apiKey}";
        
        var response = await _httpClient.GetAsync(url);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"OpenWeather error: {response.StatusCode}");
        }

        OpenWeatherDto? openWeatherDto = await response.Content.ReadFromJsonAsync<OpenWeatherDto>();

        ArgumentNullException.ThrowIfNull(openWeatherDto);

        var weather = new Weather
        {
            Temperature = openWeatherDto.Current?.Temperature ?? 0,
            Description = openWeatherDto.Current?.Weather?[0].Description ?? "",
            Icon = openWeatherDto.Current?.Weather?[0].Icon ?? "",
            Humidity = openWeatherDto.Current?.Humidity ?? 0,
            WindSpeed = openWeatherDto.Current?.WindSpeed ?? 0,
            Timezone = openWeatherDto.Timezone ?? "",
        };

        return weather;
    }
}
