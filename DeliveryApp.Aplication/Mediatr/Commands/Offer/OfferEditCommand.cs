using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.DTO;

namespace DeliveryApp.Application.Mediatr.Commands.Offer;

public class OfferEditCommand : ICommand<ResultT<JsonResponse>>
{
    public Guid Id { get; set; }
    public OfferDtoForEdit OfferDto { get; set; }
}