using DeliveryApp.Application.Repositories;
using DeliveryApp.Commons.Commands;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;

namespace DeliveryApp.Application.Mediatr.Handlers.Restaurant;

public class RestaurantDeleteCommandHandler : ICommandHandler<DeleteCommand, Result>
{
    private readonly IRestaurantRepository _restaurantRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RestaurantDeleteCommandHandler(IRestaurantRepository restaurantRepository, IUnitOfWork unitOfWork)
    {
        _restaurantRepository = restaurantRepository ?? throw new ArgumentNullException(nameof(restaurantRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<Result> Handle(DeleteCommand request, CancellationToken cancellationToken)
    {
        var result = await _restaurantRepository.DeleteRestaurant(request.Id, cancellationToken);
        if (result is false) return Result.Failure($"Restaurant with id {request.Id} can not be deleted");

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success("Restaurant deleted successfully");
    }
}