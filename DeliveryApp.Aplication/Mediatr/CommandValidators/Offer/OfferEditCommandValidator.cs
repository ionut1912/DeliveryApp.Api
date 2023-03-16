using DeliveryApp.Application.Mediatr.Commands.Offer;
using FluentValidation;

namespace DeliveryApp.Application.Mediatr.CommandValidators.Offer;

public class OfferEditCommandValidator : AbstractValidator<OfferEditCommand>
{
    public OfferEditCommandValidator()
    {
        RuleFor(x => x.OfferDto.DateActiveFrom)
            .NotEmpty()
            .GreaterThan(DateTime.Now.ToString());

        RuleFor(x => x.OfferDto.DateActiveTo)
            .NotEmpty()
            .GreaterThan(DateTime.Now.ToString());
        RuleFor(x => x.OfferDto.MenuItemId)
            .NotEmpty();
    }
}