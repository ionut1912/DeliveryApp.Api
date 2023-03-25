using DeliveryApp.Application.Mediatr.Query.Restaurant;
using DeliveryApp.Application.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;

namespace DeliveryApp.Application.Mediatr.Handlers.Restaurant;

public class
    RestaurantQueryItemByCityHandler : IQueryHandler<RestaurantQueryItemByCity, ResultT<List<Domain.Models.RestaurantWithImage>>>
{
    private readonly IRestaurantRepository _restaurantRepository;

    public RestaurantQueryItemByCityHandler(IRestaurantRepository restaurantRepository)
    {
        _restaurantRepository =
            restaurantRepository ?? throw new ArgumentNullException(nameof(restaurantRepository));
    }

    public async Task<ResultT<List<Domain.Models.RestaurantWithImage>>> Handle(RestaurantQueryItemByCity request,
        CancellationToken cancellationToken)
    {
        var result = await _restaurantRepository.GetRestaurantsByCity(request.City, cancellationToken);
        return ResultT<List<Domain.Models.RestaurantWithImage>>.Success(result);
    }
}