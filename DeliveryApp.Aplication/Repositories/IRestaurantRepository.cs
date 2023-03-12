using DeliveryApp.Domain.DTO;
using DeliveryApp.Domain.Models;

namespace DeliveryApp.Application.Repositories;

public interface IRestaurantRepository
{
    Task AddRestaurant(RestaurantDto restaurantDto, CancellationToken cancellationToken);
    Task<List<Restaurant>> GetRestaurants(CancellationToken cancellationToken);
    Task<Restaurant> GetRestaurant(Guid id, CancellationToken cancellationToken);
   Task<List<Restaurant>> GetRestaurantsByCity(string city, CancellationToken cancellationToken);
    Task<bool> EditRestaurant(Guid id, RestaurantDto restaurantDto, CancellationToken cancellationToken);
    Task<bool> DeleteRestaurant(Guid id, CancellationToken cancellationToken);
}