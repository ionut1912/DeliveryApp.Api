using DeliveryApp.Aplication.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Commons.Query;

namespace DeliveryApp.Aplication.Mediatr.Handlers.Restaurant;

public class RestaurantListQueryHandler : IQueryHandler<
    ListQuery<Domain.Models.RestaurantDto>,
    ResultT<List<Domain.Models.RestaurantDto>>>
{
    private readonly IRestaurantRepository _restaurantRepository;

    public RestaurantListQueryHandler(IRestaurantRepository restaurantRepository)
    {
        _restaurantRepository = restaurantRepository ?? throw new ArgumentNullException(nameof(restaurantRepository));
    }

    public async Task<ResultT<List<Domain.Models.RestaurantDto>>> Handle(
        ListQuery<Domain.Models.RestaurantDto> request,
        CancellationToken cancellationToken)
    {
        return await _restaurantRepository.GetRestaurants(request, cancellationToken);
    }
}