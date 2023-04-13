using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.DTO;

namespace DeliveryApp.Application.Mediatr.Commands.Restaurant;

public class RestaurantCreateCommand : ICommand<ResultT<JsonResponse>>
{
    public RestaurantDto RestaurantDto { get; set; }
}