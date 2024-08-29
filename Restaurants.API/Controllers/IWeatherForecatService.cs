
namespace Restaurants.API.Controllers
{
    public interface IWeatherForecatService
    {
        IEnumerable<WeatherForecast> Get();
    }
}