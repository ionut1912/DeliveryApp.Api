using DeliveryApp.Application.Mediatr.Commands.Offer;
using FluentValidation;

namespace DeliveryApp.Application.Mediatr.CommandValidators.Offer;

public class OfferEditCommandValidator : AbstractValidator<OfferEditCommand>
{
    public OfferEditCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.OfferDto.Discount).NotEmpty();
    }
}