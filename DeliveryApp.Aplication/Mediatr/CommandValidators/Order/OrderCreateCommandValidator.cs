using DeliveryApp.Application.Mediatr.Commands.Order;
using FluentValidation;

namespace DeliveryApp.Application.Mediatr.CommandValidators.Order;

public class OrderCreateCommandValidator : AbstractValidator<OrderCreateCommand>
{
    public OrderCreateCommandValidator()
    {
        RuleFor(x => x.Order.RestaurantName).NotEmpty();
        RuleFor(x => x.Order.ReceivedTime).NotEmpty()
            .GreaterThan(DateTime.Now.ToString())
        RuleFor(x => x.Order.MenuItemNames).NotEmpty();
    }
}