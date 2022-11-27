using DeliveryApp.Aplication.Mediatr.Commands;
using FluentValidation;

namespace DeliveryApp.Aplication.Mediatr.CommandValidators;

public class MenuItemCreateCommandValidator : AbstractValidator<MenuItemCreateCommand>
{
    public MenuItemCreateCommandValidator()
    {
        RuleFor(x => x.menuItemForCreation.itemName).NotEmpty().WithMessage("Menu item name should not be empty");
        RuleFor(x => x.menuItemForCreation.category).NotEmpty().WithMessage("category should not be empty");
        RuleFor(x => x.menuItemForCreation.ingredients).NotEmpty().WithMessage("ingredients should not be empty");
        RuleFor(x => x.menuItemForCreation.price).NotEmpty().WithMessage("price should not be empty").GreaterThan(0)
            .WithMessage("price should be greater than 0");
        RuleFor(x => x.menuItemForCreation.quantity).NotEmpty().WithMessage("quantity should not be empty")
            .GreaterThan(0)
            .WithMessage("quantity should be grater than 0");
    }
}