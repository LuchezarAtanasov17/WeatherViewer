using Microsoft.AspNetCore.Mvc;
using WeatherApi.Models;
using WeatherApi.Services;

namespace WeatherApi.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherController(IWeatherService weatherService) 
    : Controller
{
    private readonly IWeatherService _weatherService = weatherService;

    [HttpGet]
    public async Task<IActionResult> GetWeather(
        [FromQuery] 
        double lat,
        [FromQuery] 
        double lon)
    {
        if (lat < -90 || lat > 90 || lon < -180 || lon > 180)
        {
            return BadRequest("Invalid latitude or longitude.");
        }

        try
        {
            Weather result = await _weatherService.GetWeather(lat, lon);

            return Ok(result);
        }
        catch (Exception ex)
        {
            var problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status502BadGateway,
                Title = "An error has occurred while getting weather.",
                Detail = ex.Message,
            };

            return StatusCode(StatusCodes.Status502BadGateway, problemDetails);
        }
    }
}
