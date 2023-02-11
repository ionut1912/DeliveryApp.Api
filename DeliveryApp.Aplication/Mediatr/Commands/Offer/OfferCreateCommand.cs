using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;

namespace DeliveryApp.Aplication.Mediatr.Commands.Offer;

public class OfferCreateCommand : ICommand<Result<Domain.Models.Offer>>
{
    public Domain.Models.Offer OfferForCreation { get; set; }
}