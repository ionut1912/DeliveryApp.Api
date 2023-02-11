using DeliveryApp.Aplication.Mediatr.Commands.Restaurant;
using DeliveryApp.Aplication.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;

namespace DeliveryApp.Aplication.Mediatr.Handlers.Restaurant;

public class RestaurantCreateCommandHandler : ICommandHandler<RestaurantCreateCommand,
    Result<Domain.Models.Restaurant>>
{
    private readonly IRestaurantRepository _restaurantRepository;

    public RestaurantCreateCommandHandler(IRestaurantRepository restaurantRepository)
    {
        _restaurantRepository = restaurantRepository ?? throw new ArgumentNullException(nameof(restaurantRepository));
    }

    public async Task<Result<Domain.Models.Restaurant>> Handle(
        RestaurantCreateCommand request, CancellationToken cancellationToken)
    {
        return await _restaurantRepository.AddRestaurant(request, cancellationToken);
    }
}