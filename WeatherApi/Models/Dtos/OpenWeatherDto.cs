namespace WeatherApi.Models.Dtos;

/// <summary>
/// Represents an open weather Dto.
/// </summary>
public record class OpenWeatherDto
{
    /// <summary>
    /// Gets or sets the timezone.
    /// </summary>
    public string? timezone { get; set; }

    /// <summary>
    /// Gets or sets the current Dto.
    /// </summary>
    public CurrentDto? current { get; set; }
}
