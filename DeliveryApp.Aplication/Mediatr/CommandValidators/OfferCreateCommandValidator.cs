using DeliveryApp.Aplication.Mediatr.Commands;
using FluentValidation;

namespace DeliveryApp.Aplication.Mediatr.CommandValidators;

public class OfferCreateCommandValidator : AbstractValidator<OfferCreateCommand>
{
    public OfferCreateCommandValidator()
    {
        RuleFor(x => x.offerForCreation.dateActiveFrom).NotEmpty()
            .WithMessage("Date active from should not be empty")
            .GreaterThan(DateTime.Now.ToString())
            .WithMessage("Date active from should be grater than current date");

        RuleFor(x => x.offerForCreation.dateActiveTo).NotEmpty().WithMessage("Date active to should not be empty")
            .GreaterThan(DateTime.Now.ToString()).WithMessage("Date active to should be grater than current date");
        ;
        RuleFor(x => x.offerForCreation.menuItemId).NotEmpty().WithMessage("Add a menu item id");
    }
}