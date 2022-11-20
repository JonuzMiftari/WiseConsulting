using Microsoft.AspNetCore.Mvc;
using WiseConsulting.Application.WeatherForecasts.Queries.GetWeatherForecasts;

namespace WebUI_Angular.Controllers;
public class WeatherForecastController : ApiControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<WeatherForecast>> Get()
    {
        return await Mediator.Send(new GetWeatherForecastsQuery());
    }
}
