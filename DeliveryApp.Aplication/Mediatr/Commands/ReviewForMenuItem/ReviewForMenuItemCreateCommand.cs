using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Contracts;
using DeliveryApp.Domain.DTO;

namespace DeliveryApp.Application.Mediatr.Commands.ReviewForMenuItem;

public class ReviewForMenuItemCreateCommand : ICommand<ResultT<JsonResponse>>
{
    public AddReviewForMenuItemRequest Request { get; set; }

}