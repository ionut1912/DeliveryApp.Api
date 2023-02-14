using DeliveryApp.Application.Mediatr.Commands.Restaurant;
using FluentValidation;

namespace DeliveryApp.Application.Mediatr.CommandValidators.Restaurant;

public class RestaurantCreateCommandValidator : AbstractValidator<RestaurantCreateCommand>
{
    public RestaurantCreateCommandValidator()
    {
        RuleFor(x => x.RestaurantDto.Name).NotEmpty().WithMessage("Restaurant name should not be empty");
        RuleFor(x => x.RestaurantDto.Address).NotEmpty().WithMessage("Restaurant Address should Not be empty");
    }
}