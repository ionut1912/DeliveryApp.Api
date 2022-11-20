using DeliveryApp.Aplication.Mediatr.Commands;
using FluentValidation;

namespace DeliveryApp.Aplication.Mediatr.CommandValidators
{
    public class OfferEditCommandValidator : AbstractValidator<OfferEditCommand>
    {
        public OfferEditCommandValidator()
        {
            RuleFor(x => x.offerForUpdate.dateActiveFrom).NotEmpty().WithMessage("Date active from should not be empty")
                .GreaterThan(DateTime.Now.ToString()).WithMessage("Date active from should be grater than current date");

            RuleFor(x => x.offerForUpdate.dateActiveTo).NotEmpty().WithMessage("Date active to should not be empty")
                .GreaterThan(DateTime.Now.ToString()).WithMessage("Date active to should be grater than current date");
            RuleFor(x => x.offerForUpdate.menuItemId).NotEmpty().WithMessage("Add a menu item id");
        }
    }
    }

