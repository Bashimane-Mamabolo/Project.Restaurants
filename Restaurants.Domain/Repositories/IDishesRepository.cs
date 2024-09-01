using Restaurants.Domain.Entities;

namespace Restaurants.Infrastructure.Repositories;

public interface IDishesRepository
{
    Task<int> Create(Dish entity);
    Task Delete(IEnumerable<Dish> entities);
}
