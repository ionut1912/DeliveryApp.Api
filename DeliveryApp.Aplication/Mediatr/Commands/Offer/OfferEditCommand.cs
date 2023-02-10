using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Models;
using MediatR;

namespace DeliveryApp.Aplication.Mediatr.Commands.Offer;

public class OfferEditCommand : ICommand<Result<Unit>>
{
    public Guid Id { get; set; }
    public OfferForUpdate OfferForUpdate { get; set; }
}