using DeliveryApp.Aplication.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Commons.Query;

namespace DeliveryApp.Aplication.Mediatr.Handlers.Restaurant;

public class RestaurantQueryItemHandler : IQueryHandler<
    QueryItem<Domain.Models.RestaurantDto>,
    ResultT<Domain.Models.RestaurantDto>>
{
    private readonly IRestaurantRepository _restaurantRepository;

    public RestaurantQueryItemHandler(IRestaurantRepository restaurantRepository)
    {
        _restaurantRepository = restaurantRepository ?? throw new ArgumentNullException(nameof(restaurantRepository));
    }

    public async Task<ResultT<Domain.Models.RestaurantDto>> Handle(
        QueryItem<Domain.Models.RestaurantDto> request,
        CancellationToken cancellationToken)
    {
        return await _restaurantRepository.GetRestaurant(request, cancellationToken);
    }
}