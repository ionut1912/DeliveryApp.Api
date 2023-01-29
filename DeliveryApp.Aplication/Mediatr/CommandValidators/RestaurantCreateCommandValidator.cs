using DeliveryApp.Aplication.Mediatr.Commands;
using FluentValidation;

namespace DeliveryApp.Aplication.Mediatr.CommandValidators;

public class RestaurantCreateCommandValidator : AbstractValidator<RestaurantCreateCommand>
{
    public RestaurantCreateCommandValidator()
    {
        RuleFor(x => x.RestaurantForCreation.Name).NotEmpty().WithMessage("Restaurant name should not be empty");
        RuleFor(x => x.RestaurantForCreation.Address).NotEmpty().WithMessage("Restaurant Address should Not be empty");
    }
}