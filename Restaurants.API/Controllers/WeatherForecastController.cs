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
    [Route("{take}/example")]
    public IEnumerable<WeatherForecast> Get([FromQuery] int max, [FromRoute] int take)
    {
        var result = _weatherForecatService.Get();
        return result;
    }
    // Passing parameters to the action
    // Data/Model binding [FromQuery] [FromRoute] -- source of param in the endpoint
    // same route action
    [HttpGet("currentDay")]
    //[Route("currentDay")]
    public WeatherForecast GetCurrentForecast()
    {
        var result = _weatherForecatService.Get().First();
        return result;
    }
    [HttpPost]
    public string Hello([FromBody] string name)
    {
        return $"Hello {name}";
    }
}
