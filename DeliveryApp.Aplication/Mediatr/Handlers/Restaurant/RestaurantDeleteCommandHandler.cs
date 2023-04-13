using DeliveryApp.Application.Repositories;
using DeliveryApp.Commons.Commands;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Messages;

namespace DeliveryApp.Application.Mediatr.Handlers.Restaurant;

public class RestaurantDeleteCommandHandler : ICommandHandler<DeleteCommand, ResultT<JsonResponse>>
{
    private readonly IRestaurantRepository _restaurantRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RestaurantDeleteCommandHandler(IRestaurantRepository restaurantRepository, IUnitOfWork unitOfWork)
    {
        _restaurantRepository = restaurantRepository ?? throw new ArgumentNullException(nameof(restaurantRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<ResultT<JsonResponse>> Handle(DeleteCommand request, CancellationToken cancellationToken)
    {
        var result = await _restaurantRepository.DeleteRestaurant(request.Id, cancellationToken);
        if (result is false)
        {
            var jsonResponseFailure = new JsonResponse
            {
                Message = DomainMessages.Restaurant.CanNotDeleteRestaurant(request.Id)
            };
            return ResultT<JsonResponse>.Failure(jsonResponseFailure.Message);
        }

        var jsonResponseSuccess = new JsonResponse
        {
            Message = DomainMessages.Restaurant.RestaurantDeletedSuccessfully(request.Id)
        };

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return ResultT<JsonResponse>.Success(jsonResponseSuccess);
    }
}