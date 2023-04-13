using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;

namespace DeliveryApp.Application.Mediatr.Commands.Photo;

public class PhotoForRestaurantDeleteCommand : ICommand<ResultT<JsonResponse>>
{
    public string PhotoId { get; set; }
    public Guid Id { get; set; }
}