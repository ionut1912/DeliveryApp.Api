using DeliveryApp.Aplication.Mediatr.Commands.Offer;
using FluentValidation;

namespace DeliveryApp.Aplication.Mediatr.CommandValidators.Offer;

public class OfferEditCommandValidator : AbstractValidator<OfferEditCommand>
{
    public OfferEditCommandValidator()
    {
        RuleFor(x => x.OfferForUpdate.DateActiveFrom).NotEmpty().WithMessage("Date active from should not be empty")
            .GreaterThan(DateTime.Now.ToString()).WithMessage("Date active from should be grater than current date");

        RuleFor(x => x.OfferForUpdate.DateActiveTo).NotEmpty().WithMessage("Date active to should not be empty")
            .GreaterThan(DateTime.Now.ToString()).WithMessage("Date active to should be grater than current date");
        RuleFor(x => x.OfferForUpdate.MenuItemId).NotEmpty().WithMessage("Add a menu item id");
    }
}