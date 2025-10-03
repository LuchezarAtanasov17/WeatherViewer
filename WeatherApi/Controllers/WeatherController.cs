using Microsoft.AspNetCore.Mvc;
using WeatherApi.Extensions;
using WeatherApi.Models;
using WeatherApi.Services;

namespace WeatherApi.Controllers;

/// <summary>
/// Provides operations for working with weather.
/// </summary>
/// <param name="weatherService">the weather service</param>
[ApiController]
[Route("[controller]")]
public class WeatherController(IWeatherService weatherService)
    : ControllerBase
{
    private readonly IWeatherService _weatherService = weatherService;

    /// <summary>
    /// Gets weather.
    /// </summary>
    /// <param name="lat">the latitude</param>
    /// <param name="lon">the longitude</param>
    /// <param name="excludeParts">the exclude parts</param>
    /// <returns>the weather</returns>
    [HttpGet]
    public async Task<IActionResult> GetWeather(
        [FromQuery]
        double lat,
        [FromQuery]
        double lon,
        [FromQuery]
        string[] excludeParts)
    {
        if (lat < -90 || lat > 90 || lon < -180 || lon > 180)
        {
            return BadRequest("Invalid latitude or longitude.");
        }

        try
        {
            Weather result = await _weatherService.GetWeather(lat, lon, excludeParts);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return this.HandleException(ex, "An error has occurred while getting weather.");
        }
    }
}
