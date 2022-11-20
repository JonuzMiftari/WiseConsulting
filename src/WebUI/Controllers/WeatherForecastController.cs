using MediatR;
using Microsoft.AspNetCore.Mvc;
using WiseConsulting.Application.WeatherForecasts.Queries.GetWeatherForecasts;

namespace WebUI.Controllers;
//[Authorize]
[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private ISender _mediator = null!;

    private ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task<IEnumerable<WeatherForecast>> Get() => await Mediator.Send(new GetWeatherForecastsQuery());
}
