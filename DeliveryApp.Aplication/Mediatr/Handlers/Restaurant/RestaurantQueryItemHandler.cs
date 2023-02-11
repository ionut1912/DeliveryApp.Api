using DeliveryApp.Aplication.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Commons.Query;

namespace DeliveryApp.Aplication.Mediatr.Handlers.Restaurant;

public class RestaurantQueryItemHandler : IQueryHandler<
    QueryItem<Domain.Models.Restaurant>,
    Result<Domain.Models.Restaurant>>
{
    private readonly IRestaurantRepository _restaurantRepository;

    public RestaurantQueryItemHandler(IRestaurantRepository restaurantRepository)
    {
        _restaurantRepository = restaurantRepository ?? throw new ArgumentNullException(nameof(restaurantRepository));
    }

    public async Task<Result<Domain.Models.Restaurant>> Handle(
        QueryItem<Domain.Models.Restaurant> request,
        CancellationToken cancellationToken)
    {
        return await _restaurantRepository.GetRestaurant(request, cancellationToken);
    }
}