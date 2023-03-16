using DeliveryApp.Application.Mediatr.Commands.Restaurant;
using FluentValidation;

namespace DeliveryApp.Application.Mediatr.CommandValidators.Restaurant;

public class RestaurantEditCommandValidator : AbstractValidator<RestaurantEditCommand>
{
    public RestaurantEditCommandValidator()
    {
        RuleFor(x => x.RestaurantForUpdate.Name).NotEmpty();
        RuleFor(x => x.RestaurantForUpdate.Address).NotEmpty();
    }
}