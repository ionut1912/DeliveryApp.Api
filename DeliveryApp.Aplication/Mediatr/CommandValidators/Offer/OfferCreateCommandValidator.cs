using DeliveryApp.Aplication.Mediatr.Commands.Offer;
using FluentValidation;

namespace DeliveryApp.Aplication.Mediatr.CommandValidators.Offer;

public class OfferCreateCommandValidator : AbstractValidator<OfferCreateCommand>
{
    public OfferCreateCommandValidator()
    {
        RuleFor(x => x.OfferDto.DateActiveFrom).NotEmpty()
            .WithMessage("Date active from should not be empty")
            .GreaterThan(DateTime.Now.ToString())
            .WithMessage("Date active from should be grater than current date");

        RuleFor(x => x.OfferDto.DateActiveFrom).NotEmpty().WithMessage("Date active to should not be empty")
            .GreaterThan(DateTime.Now.ToString()).WithMessage("Date active to should be grater than current date");
        ;
        RuleFor(x => x.OfferDto.DateActiveFrom).NotEmpty().WithMessage("Add a menu item id");
    }
}