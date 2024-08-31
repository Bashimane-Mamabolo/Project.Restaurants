using Restaurants.Domain.Entities;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Seeders;

internal class RestaurantSeeder(RestaurantsDbContext dbContext) : IRestaurantSeeder
{
    public async Task Seed()
    {
        if (await dbContext.Database.CanConnectAsync())
        {
            if (!dbContext.Restaurants.Any())
            {
                var restaurants = GetRestaurants();
                dbContext.Restaurants.AddRange(restaurants);
                await dbContext.SaveChangesAsync();
            }

        }
    }

    private IEnumerable<Restaurant> GetRestaurants()
    {
        List<Restaurant> restaurants = new List<Restaurant>
        {
            new Restaurant
            {
                Name = "KFC",
                Category = "Fast Food",
                Description = "Famous for fried chicken.",
                HasDelivery = true,
                ContactEmail = "contact@kfc.com",
                ContactNumber = "123-456-7890",
                Address = new Address
                {
                    City = "New York",
                    Street = "123 Main St",
                    PostalCode = "10001"
                },
                Dishes = new List<Dish>
                {
                    new Dish { Name = "Chicken Bucket", Description = "A bucket of crispy fried chicken.", Price = 15.99M},
                    new Dish { Name = "Fries", Description = "Crispy golden fries.", Price = 2.99M}
                }
            },
            new Restaurant
            {
                Name = "Pizza Hut",
                Category = "Fast Food",
                Description = "Delicious pizzas and more.",
                HasDelivery = true,
                ContactEmail = "contact@pizzahut.com",
                ContactNumber = "987-654-3210",
                Address = new Address
                {
                    City = "Los Angeles",
                    Street = "456 Broadway Ave",
                    PostalCode = "90001"
                },
                Dishes = new List<Dish>
                {
                    new Dish {  Name = "Pepperoni Pizza", Description = "Classic pepperoni pizza.", Price = 12.99M},
                    new Dish {Name = "Garlic Bread", Description = "Crispy garlic bread.", Price = 3.99M }
                }
            }
        };
        return restaurants;
    }
}
