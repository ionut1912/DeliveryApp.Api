using DeliveryApp.Aplication.Mediatr.Commands;
using FluentValidation;

namespace DeliveryApp.Aplication.Mediatr.CommandValidators;

public class RestaurantEditCommandValidator : AbstractValidator<RestaurantEditCommand>
{
    public RestaurantEditCommandValidator()
    {
        RuleFor(x => x.RestaurantForUpdate.Name).NotEmpty().WithMessage("Restaurant name should not be empty");
        RuleFor(x => x.RestaurantForUpdate.Address).NotEmpty()
            .WithMessage("Restaurant Address should Not be empty");
    }
}