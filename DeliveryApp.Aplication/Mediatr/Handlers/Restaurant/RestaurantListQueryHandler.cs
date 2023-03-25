using DeliveryApp.Application.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Commons.Query;

namespace DeliveryApp.Application.Mediatr.Handlers.Restaurant;

public class RestaurantListQueryHandler : IQueryHandler<
    ListQuery<Domain.Models.RestaurantWithImage>,
    ResultT<List<Domain.Models.RestaurantWithImage>>>
{
    private readonly IRestaurantRepository _restaurantRepository;

    public RestaurantListQueryHandler(IRestaurantRepository restaurantRepository)
    {
        _restaurantRepository = restaurantRepository ?? throw new ArgumentNullException(nameof(restaurantRepository));
    }

    public async Task<ResultT<List<Domain.Models.RestaurantWithImage>>> Handle(
        ListQuery<Domain.Models.RestaurantWithImage> request,
        CancellationToken cancellationToken)
    {
        var result = await _restaurantRepository.GetRestaurants(cancellationToken);
        return ResultT<List<Domain.Models.RestaurantWithImage>>.Success(result);
    }
}