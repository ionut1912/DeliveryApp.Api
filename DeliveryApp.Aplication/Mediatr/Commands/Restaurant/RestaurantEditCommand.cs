using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.DTO;
using MediatR;

namespace DeliveryApp.Aplication.Mediatr.Commands.Restaurant;

public class RestaurantEditCommand : ICommand<Result>
{
    public Guid Id { get; set; }
    public RestaurantDto RestaurantForUpdate { get; set; }
}