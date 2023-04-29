using DeliveryApp.Application.Mediatr.Commands.Order;
using FluentValidation;

namespace DeliveryApp.Application.Mediatr.CommandValidators.Order;

public class OrderEditCommandValidator : AbstractValidator<OrderEditCommand>
{
    public OrderEditCommandValidator()
    {
        RuleFor(x => x.Request.OrderForUpdate.Status).NotEmpty();
    }
}