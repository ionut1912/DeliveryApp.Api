using DeliveryApp.Application.Mediatr.Commands.ReviewForRestaurant;
using FluentValidation;

namespace DeliveryApp.Application.Mediatr.CommandValidators.ReviewForRestaurant;

public class ReviewForRestaurantCreateCommandValidator : AbstractValidator<ReviewForRestaurantCreateCommand>
{
    public ReviewForRestaurantCreateCommandValidator()
    {
        RuleFor(x => x.ReviewForRestaurantDto.ReviewTitle).NotEmpty();
        RuleFor(x => x.ReviewForRestaurantDto.ReviewDescription).NotEmpty();
        RuleFor(x => x.ReviewForRestaurantDto.RestaurantId).NotEmpty();
    }
}