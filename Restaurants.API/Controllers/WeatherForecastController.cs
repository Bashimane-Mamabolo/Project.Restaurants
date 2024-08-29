using Microsoft.AspNetCore.Mvc;

namespace Restaurants.API.Controllers;

[ApiController]
[Route("api/[controller]")]
//[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IWeatherForecatService _weatherForecatService;
    public WeatherForecastController(ILogger<WeatherForecastController> logger,
        IWeatherForecatService weatherForecatService)
    {
        _logger = logger;
        _weatherForecatService = weatherForecatService;
    }

    [HttpGet]
    [Route("example")]
    public IEnumerable<WeatherForecast> Get()
    {
        var result = _weatherForecatService.Get();
        return result;
    }
}
