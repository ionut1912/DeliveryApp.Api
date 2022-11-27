using DeliveryApp.Aplication.Mediatr.Commands;
using FluentValidation;

namespace DeliveryApp.Aplication.Mediatr.CommandValidators;

public class OrderEditCommandValidator : AbstractValidator<OrderEditCommand>
{
    public OrderEditCommandValidator()
    {
        RuleFor(x => x.orderForUpdate.status).NotEmpty().WithMessage("Status should not be empty");
    }
}