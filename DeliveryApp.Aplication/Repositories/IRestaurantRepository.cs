using DeliveryApp.Aplication.Mediatr.Commands;
using DeliveryApp.Commons.Commands;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Query;
using DeliveryApp.Repository.Entities;
using MediatR;

namespace DeliveryApp.Aplication.Repositories;

public interface IRestaurantRepository
{
    Task<Result<Restaurants>> AddRestaurant(RestaurantCreateCommand command, CancellationToken cancellationToken);
    Task<Result<List<Restaurants>>> GetRestaurants(ListQuery<Restaurants> command, CancellationToken cancellationToken);
    Task<Result<Restaurants>> GetRestaurant(QueryItem<Restaurants> query, CancellationToken cancellationToken);
    Task<Result<Unit>> EditRestaurant(RestaurantEditCommand command, CancellationToken cancellationToken);
    Task<Result<Unit>> DeleteRestaurant(DeleteCommand query, CancellationToken cancellationToken);
}