using DeliveryApp.Aplication.Mediatr.Commands.Restaurant;
using DeliveryApp.Aplication.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using MediatR;

namespace DeliveryApp.Aplication.Mediatr.Handlers.Restaurant;

public class RestaurantEditCommandHandler : ICommandHandler<RestaurantEditCommand, ResultT<Unit>>
{
    private readonly IRestaurantRepository _repository;

    public RestaurantEditCommandHandler(IRestaurantRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public async Task<ResultT<Unit>> Handle(RestaurantEditCommand request, CancellationToken cancellationToken)
    {
        return await _repository.EditRestaurant(request, cancellationToken);
    }
}