using Microsoft.AspNetCore.Mvc;

namespace WeatherApi.Controllers;

/// <summary>
/// Provides endpoints for health check.
/// </summary>
[ApiController]
[Route("[controller]")]
public class HealthController : Controller
{
    /// <summary>
    /// Returns OK if the API is available.
    /// </summary>
    /// <returns>HTTP 200 response with "OK".</returns>
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("OK");
    }
}
