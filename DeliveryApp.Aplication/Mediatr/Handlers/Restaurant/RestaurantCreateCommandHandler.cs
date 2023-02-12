using DeliveryApp.Aplication.Mediatr.Commands.Restaurant;
using DeliveryApp.Aplication.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;

namespace DeliveryApp.Aplication.Mediatr.Handlers.Restaurant;

public class RestaurantCreateCommandHandler : ICommandHandler<RestaurantCreateCommand,
    ResultT<Domain.Models.RestaurantDto>>
{
    private readonly IRestaurantRepository _restaurantRepository;

    public RestaurantCreateCommandHandler(IRestaurantRepository restaurantRepository)
    {
        _restaurantRepository = restaurantRepository ?? throw new ArgumentNullException(nameof(restaurantRepository));
    }

    public async Task<ResultT<Domain.Models.RestaurantDto>> Handle(
        RestaurantCreateCommand request, CancellationToken cancellationToken)
    {
        return await _restaurantRepository.AddRestaurant(request, cancellationToken);
    }
}