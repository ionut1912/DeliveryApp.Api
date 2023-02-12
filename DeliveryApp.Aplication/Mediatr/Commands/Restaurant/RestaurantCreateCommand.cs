using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.DTO;

namespace DeliveryApp.Aplication.Mediatr.Commands.Restaurant;

public class RestaurantCreateCommand : ICommand<Result>
{
    public RestaurantDto RestaurantDto { get; set; }
}