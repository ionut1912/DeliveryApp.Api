using DeliveryApp.Application.Mediatr.Commands.ReviewForRestaurant;
using DeliveryApp.Application.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Messages;

namespace DeliveryApp.Application.Mediatr.Handlers.ReviewForRestaurant;

public class
    ReviewForRestaurantEditCommandHandler : ICommandHandler<ReviewForRestaurantEditCommand, ResultT<JsonResponse>>
{
    private readonly IReviewForRestaurantRepository _reviewForRestaurantRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ReviewForRestaurantEditCommandHandler(IReviewForRestaurantRepository reviewForRestaurantRepository,
        IUnitOfWork unitOfWork)
    {
        _reviewForRestaurantRepository = reviewForRestaurantRepository ??
                                         throw new ArgumentNullException(nameof(reviewForRestaurantRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<ResultT<JsonResponse>> Handle(ReviewForRestaurantEditCommand request,
        CancellationToken cancellationToken)
    {
        var result =
            await _reviewForRestaurantRepository.EditReviewForRestaurant(request.Id, request.ReviewForRestaurant,
                cancellationToken);
        if (result is false)
        {
            var jsonResponseFailure = new JsonResponse
            {
                Message = DomainMessages.ReviewForRestaurant.CanNotEditReview(request.Id,
                    request.ReviewForRestaurant.RestaurantId)
            };
            return ResultT<JsonResponse>.Failure(jsonResponseFailure.Message);
        }


        await _unitOfWork.SaveChangesAsync(cancellationToken);
        var jsonResponseSuccess = new JsonResponse
        {
            Message = DomainMessages.ReviewForRestaurant.ReviewEdited(request.Id)
        };
        return ResultT<JsonResponse>.Success(jsonResponseSuccess);
    }
}