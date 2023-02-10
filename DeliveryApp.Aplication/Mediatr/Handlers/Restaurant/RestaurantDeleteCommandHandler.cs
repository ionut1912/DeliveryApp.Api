using DeliveryApp.Aplication.Repositories;
using DeliveryApp.Commons.Commands;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using MediatR;

namespace DeliveryApp.Aplication.Mediatr.Handlers.Restaurant;

public class RestaurantDeleteCommandHandler : ICommandHandler<DeleteCommand, Result<Unit>>
{
    private readonly IRestaurantRepository _restaurantRepository;

    public RestaurantDeleteCommandHandler(IRestaurantRepository restaurantRepository)
    {
        _restaurantRepository =
            restaurantRepository ?? throw new ArgumentNullException(nameof(restaurantRepository));
    }

    public async Task<Result<Unit>> Handle(DeleteCommand request, CancellationToken cancellationToken)
    {
        return await _restaurantRepository.DeleteRestaurant(request, cancellationToken);
    }
}