using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Models;
using MediatR;

namespace DeliveryApp.Aplication.Mediatr.Commands;

public class OfferEditCommand : ICommand<Result<Unit>>
{
    public Guid id { get; set; }
    public OfferForUpdate offerForUpdate { get; set; }
}