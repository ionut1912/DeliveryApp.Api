using DeliveryApp.Aplication.Mediatr.Commands;
using FluentValidation;

namespace DeliveryApp.Aplication.Mediatr.CommandValidators;

public class MenuItemEditCommandValidator : AbstractValidator<MenuItemEditCommand>
{
    public MenuItemEditCommandValidator()
    {
        RuleFor(x => x.menuItemForUpdate.itemName).NotEmpty().WithMessage("Menu item name should not be empty");
        RuleFor(x => x.menuItemForUpdate.category).NotEmpty().WithMessage("category should not be empty");
        RuleFor(x => x.menuItemForUpdate.ingredients).NotEmpty().WithMessage("ingredients should not be empty");
        RuleFor(x => x.menuItemForUpdate.price).NotEmpty().WithMessage("price should not be empty").GreaterThan(0)
            .WithMessage("price should be greater than 0");
        RuleFor(x => x.menuItemForUpdate.quantity).NotEmpty().WithMessage("quantity should not be empty");
    }
}