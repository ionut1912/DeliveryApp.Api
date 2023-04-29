using DeliveryApp.Application.Mediatr.Commands.ReviewForRestaurant;
using FluentValidation;

namespace DeliveryApp.Application.Mediatr.CommandValidators.ReviewForRestaurant;

public class ReviewForRestaurantCreateCommandValidator : AbstractValidator<ReviewForRestaurantCreateCommand>
{
    public ReviewForRestaurantCreateCommandValidator()
    {
        RuleFor(x => x.Request.ReviewForRestaurantDto.ReviewTitle).NotEmpty();
        RuleFor(x => x.Request.ReviewForRestaurantDto.ReviewDescription).NotEmpty();
        RuleFor(x => x.Request.ReviewForRestaurantDto.RestaurantId).NotEmpty();
    }
}