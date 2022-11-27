using DeliveryApp.Aplication.Mediatr.Commands;
using FluentValidation;

namespace DeliveryApp.Aplication.Mediatr.CommandValidators;

public class OrderCreateCommandValidator : AbstractValidator<OrderCreateCommand>
{
    public OrderCreateCommandValidator()
    {
        RuleFor(x => x.order.restaurantName).NotEmpty().WithMessage("Restaurant name should not be empty");
        RuleFor(x => x.order.receivedTime).NotEmpty().WithMessage("Received time should not be empty")
            .GreaterThan(DateTime.Now.ToString())
            .WithMessage("Received time should be later than current date time");
        RuleFor(x => x.order.username).NotEmpty().WithMessage("Username should not be empty");
        RuleFor(x => x.order.menuItemNames).NotEmpty().WithMessage("Menu Items list should not be empty");
    }
}