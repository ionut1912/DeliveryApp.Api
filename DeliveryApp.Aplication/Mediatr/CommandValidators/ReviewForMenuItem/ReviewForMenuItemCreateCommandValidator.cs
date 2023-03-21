using DeliveryApp.Application.Mediatr.Commands.ReviewForMenuItem;
using FluentValidation;

namespace DeliveryApp.Application.Mediatr.CommandValidators.ReviewForMenuItem;

public class ReviewForMenuItemCreateCommandValidator : AbstractValidator<ReviewForMenuItemCreateCommand>
{
    public ReviewForMenuItemCreateCommandValidator()
    {
        RuleFor(x => x.ReviewForMenuItemDto.ReviewTitle).NotEmpty();
        RuleFor(x => x.ReviewForMenuItemDto.ReviewDescription).NotEmpty();
        RuleFor(x => x.ReviewForMenuItemDto.MenuItemId).NotEmpty();
    }
}