using DeliveryApp.Application.Mediatr.Commands.Order;
using FluentValidation;

namespace DeliveryApp.Application.Mediatr.CommandValidators.Order;

public class OrderCreateCommandValidator : AbstractValidator<OrderCreateCommand>
{
    public OrderCreateCommandValidator()
    {
        RuleFor(x => x.Request.Order.RestaurantNames).NotEmpty();

        RuleFor(x => x.Request.Order.MenuItems).NotEmpty();
    }
}