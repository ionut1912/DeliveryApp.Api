using DeliveryApp.Aplication.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Commons.Query;

namespace DeliveryApp.Aplication.Mediatr.Handlers.Restaurant;

public class RestaurantListQueryHandler : IQueryHandler<
    ListQuery<Domain.Models.Restaurant>,
    Result<List<Domain.Models.Restaurant>>>
{
    private readonly IRestaurantRepository _restaurantRepository;

    public RestaurantListQueryHandler(IRestaurantRepository restaurantRepository)
    {
        _restaurantRepository = restaurantRepository ?? throw new ArgumentNullException(nameof(restaurantRepository));
    }

    public async Task<Result<List<Domain.Models.Restaurant>>> Handle(
        ListQuery<Domain.Models.Restaurant> request,
        CancellationToken cancellationToken)
    {
        return await _restaurantRepository.GetRestaurants(request, cancellationToken);
    }
}