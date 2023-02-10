using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Models;
using DeliveryApp.Repository.Entities;

namespace DeliveryApp.Aplication.Mediatr.Commands.Restaurant;

public class RestaurantCreateCommand : ICommand<Result<Restaurants>>
{
    public RestaurantForCreation RestaurantForCreation { get; set; }
}