using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Models;
using MediatR;

namespace DeliveryApp.Aplication.Mediatr.Commands.Restaurant;

public class RestaurantEditCommand : ICommand<Result<Unit>>
{
    public Guid Id { get; set; }
    public RestaurantForUpdate RestaurantForUpdate { get; set; }
}