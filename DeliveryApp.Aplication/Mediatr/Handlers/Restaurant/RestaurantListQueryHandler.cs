using DeliveryApp.Application.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Commons.Query;
using DeliveryApp.Domain.Models;

namespace DeliveryApp.Application.Mediatr.Handlers.Restaurant;

public class RestaurantListQueryHandler : IQueryHandler<
    ListQuery<Domain.Models.Restaurant>,
    ResultT<List<Domain.Models.Restaurant>>>
{
    private readonly IRestaurantRepository _restaurantRepository;

    public RestaurantListQueryHandler(IRestaurantRepository restaurantRepository)
    {
        _restaurantRepository = restaurantRepository ?? throw new ArgumentNullException(nameof(restaurantRepository));
    }

    public async Task<ResultT<List<Domain.Models.Restaurant>>> Handle(
        ListQuery<Domain.Models.Restaurant> request,
        CancellationToken cancellationToken)
    {
        var result = await _restaurantRepository.GetRestaurants(cancellationToken);
        return ResultT<List<Domain.Models.Restaurant>>.Success(result);
    }
}