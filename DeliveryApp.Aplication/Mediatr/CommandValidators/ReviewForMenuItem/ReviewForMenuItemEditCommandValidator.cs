using DeliveryApp.Application.Mediatr.Commands.ReviewForMenuItem;
using FluentValidation;

namespace DeliveryApp.Application.Mediatr.CommandValidators.ReviewForMenuItem;

public class ReviewForMenuItemEditCommandValidator : AbstractValidator<ReviewForMenuItemEditCommand>
{
    public ReviewForMenuItemEditCommandValidator()
    {
        RuleFor(x => x.Request.ReviewForMenuItemDto.ReviewTitle).NotEmpty();
        RuleFor(x => x.Request.ReviewForMenuItemDto.ReviewDescription).NotEmpty();
        RuleFor(x => x.Request.ReviewForMenuItemDto.MenuItemId).NotEmpty();
    }
}