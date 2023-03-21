using DeliveryApp.Application.Mediatr.Commands.ReviewForRestaurant;
using FluentValidation;

namespace DeliveryApp.Application.Mediatr.CommandValidators.ReviewForRestaurant;

public class ReviewForRestaurantEditCommandValidator : AbstractValidator<ReviewForRestaurantEditCommand>
{
    public ReviewForRestaurantEditCommandValidator()
    {
        RuleFor(x => x.ReviewForRestaurant.ReviewTitle).NotEmpty();
        RuleFor(x => x.ReviewForRestaurant.ReviewDescription).NotEmpty();
        RuleFor(x => x.ReviewForRestaurant.RestaurantId).NotEmpty();
    }
}