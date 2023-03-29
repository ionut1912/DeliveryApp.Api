using DeliveryApp.Application.Mediatr.Commands.Order;
using FluentValidation;

namespace DeliveryApp.Application.Mediatr.CommandValidators.Order;

public class OrderCreateCommandValidator : AbstractValidator<OrderCreateCommand>
{
    public OrderCreateCommandValidator()
    {
        RuleFor(x => x.Order.RestaurantNames).NotEmpty();

        RuleFor(x => x.Order.MenuItems).NotEmpty();
    }
}