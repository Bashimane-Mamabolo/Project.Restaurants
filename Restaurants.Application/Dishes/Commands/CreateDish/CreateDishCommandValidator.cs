using FluentValidation;

namespace Restaurants.Application.Dishes.Commands.CreateDish;

internal class CreateDishCommandValidator : AbstractValidator<CreateDishCommand>
{
    public CreateDishCommandValidator()
    {
        RuleFor(dish => dish.Price)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Price must be a non-negative number.");

        RuleFor(dish => dish.Kilocalories)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Kilocalories must be a non-negative number.");
    }
}
