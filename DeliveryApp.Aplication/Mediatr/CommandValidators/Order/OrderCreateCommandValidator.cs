using DeliveryApp.Application.Mediatr.Commands.Order;
using FluentValidation;

namespace DeliveryApp.Application.Mediatr.CommandValidators.Order;

public class OrderCreateCommandValidator : AbstractValidator<OrderCreateCommand>
{
    public OrderCreateCommandValidator()
    {
        RuleFor(x => x.Order.RestaurantName).NotEmpty().WithMessage("Restaurant name should not be empty");
        RuleFor(x => x.Order.ReceivedTime).NotEmpty().WithMessage("Received time should not be empty")
            .GreaterThan(DateTime.Now.ToString())
            .WithMessage("Received time should be later than current date time");
        RuleFor(x => x.Order.Username).NotEmpty().WithMessage("Username should not be empty");
        RuleFor(x => x.Order.MenuItemNames).NotEmpty().WithMessage("Menu Items list should not be empty");
    }
}