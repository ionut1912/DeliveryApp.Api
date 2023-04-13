using DeliveryApp.Application.Mediatr.Commands.Restaurant;
using DeliveryApp.Application.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Messages;

namespace DeliveryApp.Application.Mediatr.Handlers.Restaurant;

public class RestaurantEditCommandHandler : ICommandHandler<RestaurantEditCommand, ResultT<JsonResponse>>
{
    private readonly IRestaurantRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public RestaurantEditCommandHandler(IRestaurantRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<ResultT<JsonResponse>> Handle(RestaurantEditCommand request, CancellationToken cancellationToken)
    {
        var result = await _repository.EditRestaurant(request.Id, request.RestaurantForUpdate, cancellationToken);
        if (result is false)
        {
            var jsonResponseFailure = new JsonResponse
            {
                Message = DomainMessages.Restaurant.CanNotEditRestaurant(request.Id)
            };

            return ResultT<JsonResponse>.Failure(jsonResponseFailure.Message);
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        var jsonResponseSuccess = new JsonResponse
        {
            Message = DomainMessages.Restaurant.RestaurantEditedSuccessfully(request.Id)
        };

        return ResultT<JsonResponse>.Success(jsonResponseSuccess);
    }
}