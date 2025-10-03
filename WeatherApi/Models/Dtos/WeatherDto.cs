namespace WeatherApi.Models.Dtos;

/// <summary>
/// Represents a weather Dto.
/// </summary>
public class WeatherDto
{
    /// <summary>
    /// Gets or sets the description.
    /// </summary>
    public string? Description { get; set; }
    
    /// <summary>
    /// Gets or sets the icon.
    /// </summary>
    public string? Icon { get; set; }
}
