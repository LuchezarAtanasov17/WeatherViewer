namespace WeatherApi.Models.Dtos;

/// <summary>
/// Represents a current Dto.
/// </summary>
public class CurrentDto
{
    /// <summary>
    /// Gets or sets the temperature.
    /// </summary>
    public double temp { get; set; }

    /// <summary>
    /// Gets or sets the humidity.
    /// </summary>
    public int humidity { get; set; }

    /// <summary>
    /// Gets or sets the wind speed.
    /// </summary>
    public double wind_speed { get; set; }

    /// <summary>
    /// Gets or sets the weather.
    /// </summary>
    public List<WeatherDto>? weather { get; set; }
}
