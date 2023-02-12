using DeliveryApp.Aplication.Mediatr.Commands.Restaurant;
using DeliveryApp.Commons.Commands;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Query;
using DeliveryApp.Domain.DTO;
using DeliveryApp.Domain.Models;
using MediatR;

namespace DeliveryApp.Aplication.Repositories;

public interface IRestaurantRepository
{
    Task AddRestaurant(RestaurantDto restaurantDto, CancellationToken cancellationToken);
    Task<List<Restaurant>> GetRestaurants(CancellationToken cancellationToken);
    Task<Restaurant> GetRestaurant(Guid id, CancellationToken cancellationToken);
    Task<bool> EditRestaurant(Guid id,RestaurantDto restaurantDto, CancellationToken cancellationToken);
    Task<bool> DeleteRestaurant(Guid id, CancellationToken cancellationToken);
}