using DeliveryApp.Aplication.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Commons.Query;
using DeliveryApp.Repository.Entities;

namespace DeliveryApp.Aplication.Mediatr.Handlers.Restaurant;

public class RestaurantListQueryHandler : IQueryHandler<
    ListQuery<Restaurants>,
    Result<List<Restaurants>>>
{
    private readonly IRestaurantRepository _restaurantRepository;

    public RestaurantListQueryHandler(IRestaurantRepository restaurantRepository)
    {
        _restaurantRepository = restaurantRepository ?? throw new ArgumentNullException(nameof(restaurantRepository));
    }

    public async Task<Result<List<Restaurants>>> Handle(
        ListQuery<Restaurants> request,
        CancellationToken cancellationToken)
    {
        return await _restaurantRepository.GetRestaurants(request, cancellationToken);
    }
}