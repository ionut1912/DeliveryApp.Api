using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using MediatR;

namespace DeliveryApp.Aplication.Mediatr.Commands.Offer;

public class OfferEditCommand : ICommand<Result<Unit>>
{
    public Guid Id { get; set; }
    public Domain.Models.Offer OfferForUpdate { get; set; }
}