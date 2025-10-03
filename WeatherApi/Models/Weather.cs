namespace WeatherApi.Models;

/// <summary>
/// Represents a weather.
/// </summary>
public record class Weather
{
    /// <summary>
    /// Gets or sets the temperature.
    /// </summary>
    public required double Temperature { get; set; }

    /// <summary>
    /// Gets or sets the description.
    /// </summary>
    public required string Description { get; set; }

    /// <summary>
    /// Gets or sets the icon.
    /// </summary>
    public required string Icon { get; set; }

    /// <summary>
    /// Gets or sets the humidity.
    /// </summary>
    public required int Humidity { get; set; }

    /// <summary>
    /// Gets or sets the wind speed.
    /// </summary>
    public required double WindSpeed { get; set; }

    /// <summary>
    /// Gets or sets the time zone.
    /// </summary>
    public required string Timezone { get; set; }
}
