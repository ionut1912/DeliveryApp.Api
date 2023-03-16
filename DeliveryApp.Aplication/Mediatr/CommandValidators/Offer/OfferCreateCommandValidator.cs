using DeliveryApp.Application.Mediatr.Commands.Offer;
using FluentValidation;

namespace DeliveryApp.Application.Mediatr.CommandValidators.Offer;

public class OfferCreateCommandValidator : AbstractValidator<OfferCreateCommand>
{
    public OfferCreateCommandValidator()
    {
        RuleFor(x => x.OfferDto.DateActiveFrom).NotEmpty()

            .GreaterThan(DateTime.Now.ToString());

        RuleFor(x => x.OfferDto.DateActiveFrom).NotEmpty()
            .GreaterThan(DateTime.Now.ToString());
        ;
        RuleFor(x => x.OfferDto.DateActiveFrom).NotEmpty();
    }
}