using DeliveryApp.Application.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Commons.Query;

namespace DeliveryApp.Application.Mediatr.Handlers.Restaurant;

public class RestaurantQueryItemHandler : IQueryHandler<
    QueryItem<Domain.Models.Restaurant>,
    ResultT<Domain.Models.Restaurant>>
{
    private readonly IRestaurantRepository _restaurantRepository;

    public RestaurantQueryItemHandler(IRestaurantRepository restaurantRepository)
    {
        _restaurantRepository = restaurantRepository ?? throw new ArgumentNullException(nameof(restaurantRepository));
    }

    public async Task<ResultT<Domain.Models.Restaurant>> Handle(
        QueryItem<Domain.Models.Restaurant> request,
        CancellationToken cancellationToken)
    {
        var result = await _restaurantRepository.GetRestaurant(request.Id, cancellationToken);
        if (result == null)
            return ResultT<Domain.Models.Restaurant>.Failure($"Restaurant with id {request.Id} not found");
        return ResultT<Domain.Models.Restaurant>.Success(result);
    }
}