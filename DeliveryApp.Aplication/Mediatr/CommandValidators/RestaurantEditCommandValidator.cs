using DeliveryApp.Aplication.Mediatr.Commands;
using FluentValidation;

namespace DeliveryApp.Aplication.Mediatr.CommandValidators
{
    public class RestaurantEditCommandValidator : AbstractValidator<RestaurantEditCommand>
    {
        public RestaurantEditCommandValidator()
        {
            RuleFor(x => x.restaurantForUpdate.name).NotEmpty().WithMessage("Restaurant name should not be empty");
            RuleFor(x => x.restaurantForUpdate.address).NotEmpty()
                .WithMessage("Restaurant Address should Not be empty");
        }
    }
}
