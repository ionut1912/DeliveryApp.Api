using DeliveryApp.Domain.DTO;
using DeliveryApp.Domain.Models;

namespace DeliveryApp.Application.Repositories;

public interface IRestaurantRepository
{
    Task AddRestaurant(RestaurantDto restaurantDto, CancellationToken cancellationToken);
    Task<List<RestaurantWithImage>> GetRestaurants(CancellationToken cancellationToken);
    Task<RestaurantWithImages> GetRestaurant(Guid id, CancellationToken cancellationToken);
    Task<List<RestaurantWithImage>> GetRestaurantsByCity(string city, CancellationToken cancellationToken);
    Task<bool> EditRestaurant(Guid id, RestaurantDto restaurantDto, CancellationToken cancellationToken);
    Task<bool> DeleteRestaurant(Guid id, CancellationToken cancellationToken);
}