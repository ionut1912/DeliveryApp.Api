using DeliveryApp.Aplication.Mediatr.Commands;
using FluentValidation;

namespace DeliveryApp.Aplication.Mediatr.CommandValidators;

public class RestaurantCreateCommandValidator : AbstractValidator<RestaurantCreateCommand>
{
    public RestaurantCreateCommandValidator()
    {
        RuleFor(x => x.restaurantForCreation.name).NotEmpty().WithMessage("Restaurant name should not be empty");
        RuleFor(x => x.restaurantForCreation.address).NotEmpty().WithMessage("Restaurant Address should Not be empty");
    }
}