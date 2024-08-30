using Microsoft.AspNetCore.Mvc;

namespace Restaurants.API.Controllers;

public class Temperature
{
    public int minTemperature { get; set; }
    public int maxTemperature { get; set; }
}

[ApiController]
[Route("api/[controller]")]
//[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IWeatherForecastService _weatherForecastService;
    public WeatherForecastController(ILogger<WeatherForecastController> logger,
        IWeatherForecastService weatherForecastService)
    {
        _logger = logger;
        _weatherForecastService = weatherForecastService;
    }

    [HttpPost("generate")]
    public IActionResult Generate([FromQuery] int count, [FromBody] Temperature request)
    {
        if (count <= 0 || request.maxTemperature <= request.minTemperature)
        {
            return BadRequest("Count must be positive and Max temperature must be greater than Min temperature.");
        }

        var result = _weatherForecastService.Get(count, request.minTemperature, request.maxTemperature);
        return Ok(result);
    }
}



