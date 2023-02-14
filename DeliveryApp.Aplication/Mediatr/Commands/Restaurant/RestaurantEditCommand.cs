using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.DTO;

namespace DeliveryApp.Application.Mediatr.Commands.Restaurant;

public class RestaurantEditCommand : ICommand<Result>
{
    public Guid Id { get; set; }
    public RestaurantDto RestaurantForUpdate { get; set; }
}