namespace Restaurants.API;

public class WeatherForecast
{   
    //explict vs auto-implemented properties
    //i.e no, declaring of properties needed.
    public DateOnly Date { get; set; }

    public int TemperatureC { get; set; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    public string? Summary { get; set; }
}
