using DeliveryApp.Aplication.Mediatr.Commands.Order;
using FluentValidation;

namespace DeliveryApp.Aplication.Mediatr.CommandValidators.Order;

public class OrderEditCommandValidator : AbstractValidator<OrderEditCommand>
{
    public OrderEditCommandValidator()
    {
        RuleFor(x => x.OrderForUpdate.Status).NotEmpty().WithMessage("Status should not be empty");
    }
}