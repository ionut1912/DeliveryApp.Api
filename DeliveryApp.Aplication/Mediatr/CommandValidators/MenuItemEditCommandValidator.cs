using DeliveryApp.Aplication.Mediatr.Commands;
using FluentValidation;

namespace DeliveryApp.Aplication.Mediatr.CommandValidators;

public class MenuItemEditCommandValidator : AbstractValidator<MenuItemEditCommand>
{
    public MenuItemEditCommandValidator()
    {
        RuleFor(x => x.MenuItemForUpdate.ItemName).NotEmpty().WithMessage("Menu item name should not be empty");
        RuleFor(x => x.MenuItemForUpdate.Category).NotEmpty().WithMessage("category should not be empty");
        RuleFor(x => x.MenuItemForUpdate.Ingredients).NotEmpty().WithMessage("ingredients should not be empty");
        RuleFor(x => x.MenuItemForUpdate.Price).NotEmpty().WithMessage("price should not be empty").GreaterThan(0)
            .WithMessage("price should be greater than 0");
        RuleFor(x => x.MenuItemForUpdate.Quantity).NotEmpty().WithMessage("quantity should not be empty");
    }
}