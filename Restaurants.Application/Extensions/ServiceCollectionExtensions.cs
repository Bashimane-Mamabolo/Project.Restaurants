using Microsoft.Extensions.DependencyInjection;
using Restaurants.Application.Restaurants;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Repositories;
namespace Restaurants.Application.Extensions;

public static class ServiveCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IRestaurantsService, RestaurantsService>();
        //services.AddAutoMapper(typeof(ServiceCollectionExtensions).Assembly);
        services.AddAutoMapper(typeof(RestaurantsProfile));
    }
}
