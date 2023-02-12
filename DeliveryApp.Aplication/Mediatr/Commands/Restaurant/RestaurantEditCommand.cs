using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using MediatR;

namespace DeliveryApp.Aplication.Mediatr.Commands.Restaurant;

public class RestaurantEditCommand : ICommand<ResultT<Unit>>
{
    public Guid Id { get; set; }
    public Domain.Models.RestaurantDto RestaurantForUpdate { get; set; }
}