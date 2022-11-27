using DeliveryApp.Aplication.Mediatr.Commands;
using DeliveryApp.Aplication.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Repository.Entities;

namespace DeliveryApp.Aplication.Mediatr.Handlers;

public class RestaurantCreateCommandHandler : ICommandHandler<RestaurantCreateCommand,
    Result<Restaurants>>
{
    private readonly IRestaurantRepository _restaurantRepository;

    public RestaurantCreateCommandHandler(IRestaurantRepository restaurantRepository)
    {
        _restaurantRepository = restaurantRepository ?? throw new ArgumentNullException(nameof(restaurantRepository));
    }

    public async Task<Result<Restaurants>> Handle(
        RestaurantCreateCommand request, CancellationToken cancellationToken)
    {
        return await _restaurantRepository.AddRestaurant(request, cancellationToken);
    }
}