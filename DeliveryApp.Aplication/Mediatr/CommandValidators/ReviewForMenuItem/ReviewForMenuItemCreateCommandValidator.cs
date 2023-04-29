using DeliveryApp.Application.Mediatr.Commands.ReviewForMenuItem;
using FluentValidation;

namespace DeliveryApp.Application.Mediatr.CommandValidators.ReviewForMenuItem;

public class ReviewForMenuItemCreateCommandValidator : AbstractValidator<ReviewForMenuItemCreateCommand>
{
    public ReviewForMenuItemCreateCommandValidator()
    {
        RuleFor(x => x.Request.ReviewForMenuItemDto.ReviewTitle).NotEmpty();
        RuleFor(x => x.Request.ReviewForMenuItemDto.ReviewDescription).NotEmpty();
        RuleFor(x => x.Request.ReviewForMenuItemDto.MenuItemId).NotEmpty();
    }
}