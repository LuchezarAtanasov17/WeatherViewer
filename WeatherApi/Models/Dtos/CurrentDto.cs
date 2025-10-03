namespace WeatherApi.Models.Dtos;

/// <summary>
/// Represents a current Dto.
/// </summary>
public class CurrentDto
{
    /// <summary>
    /// Gets or sets the temperature.
    /// </summary>
    public double Temperature { get; set; }

    /// <summary>
    /// Gets or sets the humidity.
    /// </summary>
    public int Humidity { get; set; }

    /// <summary>
    /// Gets or sets the wind speed.
    /// </summary>
    public double WindSpeed { get; set; }

    /// <summary>
    /// Gets or sets the weather.
    /// </summary>
    public List<WeatherDto>? Weather { get; set; }
}
