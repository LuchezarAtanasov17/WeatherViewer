using Microsoft.AspNetCore.Mvc;

namespace WeatherApi.Extensions;

/// <summary>
/// Contains extension methods for controllers.
/// </summary>
public static class ControllerExtensions
{
    /// <summary>
    /// Returns a HTTP response with problem details.
    /// </summary>
    /// <param name="controller">the controller</param>
    /// <param name="ex">the exception that is the cause of the error</param>
    /// <param name="title">the title</param>
    /// <returns>the HTTP response</returns>
    public static IActionResult HandleException(
        this ControllerBase controller,
        Exception ex,
        string? title = null)
    {
        ArgumentNullException.ThrowIfNull(controller);
        ArgumentNullException.ThrowIfNull(ex);

        var problemDetails = new ProblemDetails
        {
            Status = StatusCodes.Status502BadGateway,
            Title = title,
            Detail = ex.Message,
        };

        return controller.StatusCode(StatusCodes.Status502BadGateway, problemDetails);
    }
}
