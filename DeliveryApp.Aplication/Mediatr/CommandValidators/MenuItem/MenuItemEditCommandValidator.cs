using DeliveryApp.Application.Mediatr.Commands.MenuItem;
using FluentValidation;

namespace DeliveryApp.Application.Mediatr.CommandValidators.MenuItem;

public class MenuItemEditCommandValidator : AbstractValidator<MenuItemEditCommand>
{
    public MenuItemEditCommandValidator()
    {
        RuleFor(x => x.MenuItemDto.ItemName).NotEmpty();
        RuleFor(x => x.MenuItemDto.NumberOfCalories).NotEmpty().GreaterThan(0);
        RuleFor(x => x.MenuItemDto.Category).NotEmpty();
        RuleFor(x => x.MenuItemDto.Ingredients).NotEmpty();
        RuleFor(x => x.MenuItemDto.Price).NotEmpty().GreaterThan(0);
    }
}