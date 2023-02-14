using DeliveryApp.Application.Mediatr.Commands.Restaurant;
using DeliveryApp.Application.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;

namespace DeliveryApp.Application.Mediatr.Handlers.Restaurant;

public class RestaurantEditCommandHandler : ICommandHandler<RestaurantEditCommand, Result>
{
    private readonly IRestaurantRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public RestaurantEditCommandHandler(IRestaurantRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<Result> Handle(RestaurantEditCommand request, CancellationToken cancellationToken)
    {
        var result = await _repository.EditRestaurant(request.Id, request.RestaurantForUpdate, cancellationToken);
        if (result is false) return Result.Success($"Restaurant with id {request.Id} can not be modified");

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success("Restaurant modified successfully");
    }
}