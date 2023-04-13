using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.DTO;

namespace DeliveryApp.Application.Mediatr.Commands.ReviewForMenuItem;

public class ReviewForMenuItemCreateCommand : ICommand<ResultT<JsonResponse>>
{
    public ReviewForMenuItemDto ReviewForMenuItemDto { get; set; }
}