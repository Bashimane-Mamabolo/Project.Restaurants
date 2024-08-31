using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Application.Restaurants;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Application.Restaurants.Validators;
namespace Restaurants.Application.Extensions;

public static class ServiveCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IRestaurantsService, RestaurantsService>();
        //services.AddAutoMapper(typeof(ServiceCollectionExtensions).Assembly);
        services.AddAutoMapper(typeof(RestaurantsProfile));
        //services.AddValidatorsFromAssembly(typeof(ServiceCollectionExtensions).Assembly)
        //    .AddFluentValidationAutoValidation();
        // Register validators from the assembly
        services.AddValidatorsFromAssemblyContaining<CreateRestaurantDtoValidator>();

        // Enable FluentValidation's automatic model validation
        services.AddFluentValidationAutoValidation();
    }
}
