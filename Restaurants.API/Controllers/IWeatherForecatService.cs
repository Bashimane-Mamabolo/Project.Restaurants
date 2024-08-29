
namespace Restaurants.API.Controllers
{
    public interface IWeatherForecatService
    {
        IEnumerable<WeatherForecast> Get(int count,
            int minTemperature, int maxTemperature);
    }
}