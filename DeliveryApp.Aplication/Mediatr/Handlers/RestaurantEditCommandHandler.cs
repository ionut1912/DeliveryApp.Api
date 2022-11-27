using DeliveryApp.Aplication.Mediatr.Commands;
using DeliveryApp.Aplication.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using MediatR;

namespace DeliveryApp.Aplication.Mediatr.Handlers;

public class RestaurantEditCommandHandler : ICommandHandler<RestaurantEditCommand, Result<Unit>>
{
    private readonly IRestaurantRepository _repository;

    public RestaurantEditCommandHandler(IRestaurantRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public async Task<Result<Unit>> Handle(RestaurantEditCommand request, CancellationToken cancellationToken)
    {
        return await _repository.EditRestaurant(request, cancellationToken);
    }
}