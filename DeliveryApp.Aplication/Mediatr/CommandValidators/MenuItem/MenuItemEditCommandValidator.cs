using DeliveryApp.Aplication.Mediatr.Commands.MenuItem;
using FluentValidation;

namespace DeliveryApp.Aplication.Mediatr.CommandValidators.MenuItem;

public class MenuItemEditCommandValidator : AbstractValidator<MenuItemEditCommand>
{
    public MenuItemEditCommandValidator()
    {
        RuleFor(x => x.MenuItemDto.ItemName).NotEmpty().WithMessage("Menu item name should not be empty");
        RuleFor(x => x.MenuItemDto.Category).NotEmpty().WithMessage("category should not be empty");
        RuleFor(x => x.MenuItemDto.Ingredients).NotEmpty().WithMessage("ingredients should not be empty");
        RuleFor(x => x.MenuItemDto.Price).NotEmpty().WithMessage("price should not be empty").GreaterThan(0)
            .WithMessage("price should be greater than 0");
        RuleFor(x => x.MenuItemDto.Quantity).NotEmpty().WithMessage("quantity should not be empty");
    }
}