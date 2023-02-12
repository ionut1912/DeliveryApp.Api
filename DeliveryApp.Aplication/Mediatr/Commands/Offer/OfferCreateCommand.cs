using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.DTO;

namespace DeliveryApp.Aplication.Mediatr.Commands.Offer;

public class OfferCreateCommand : ICommand<Result>
{
   public  OfferDto OfferDto { get; set; }
}