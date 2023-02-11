using DeliveryApp.Aplication.Mediatr.Commands.Restaurant;
using DeliveryApp.Commons.Commands;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Query;
using DeliveryApp.Domain.Models;
using MediatR;

namespace DeliveryApp.Aplication.Repositories;

public interface IRestaurantRepository
{
    Task<Result<Restaurant>> AddRestaurant(RestaurantCreateCommand command, CancellationToken cancellationToken);
    Task<Result<List<Restaurant>>> GetRestaurants(ListQuery<Restaurant> command, CancellationToken cancellationToken);
    Task<Result<Restaurant>> GetRestaurant(QueryItem<Restaurant> query, CancellationToken cancellationToken);
    Task<Result<Unit>> EditRestaurant(RestaurantEditCommand command, CancellationToken cancellationToken);
    Task<Result<Unit>> DeleteRestaurant(DeleteCommand query, CancellationToken cancellationToken);
}