using DeliveryApp.Application.Mediatr.CommandValidators.ReviewForRestaurant;
using DeliveryApp.Application.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Messages;

namespace DeliveryApp.Application.Mediatr.Handlers.ReviewForRestaurant;

public class
    ReviewForRestaurantDeleteCommandHandler : ICommandHandler<ReviewForRestaurantDeleteCommand, ResultT<JsonResponse>>
{
    private readonly IReviewForRestaurantRepository _reviewForRestaurantRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ReviewForRestaurantDeleteCommandHandler(IReviewForRestaurantRepository reviewForRestaurantRepository,
        IUnitOfWork unitOfWork)
    {
        _reviewForRestaurantRepository = reviewForRestaurantRepository ??
                                         throw new ArgumentNullException(nameof(reviewForRestaurantRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<ResultT<JsonResponse>> Handle(ReviewForRestaurantDeleteCommand request,
        CancellationToken cancellationToken)
    {
        var result = await _reviewForRestaurantRepository.DeleteReviewForRestaurant(request.Id, cancellationToken);
        if (result is false)
        {
            var jsonResponseFailure = new JsonResponse
            {
                Message = DomainMessages.ReviewForRestaurant.CanNoDeleteReview(request.Id)
            };
            return ResultT<JsonResponse>.Failure(jsonResponseFailure.Message);
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        var jsonResponseSuccess = new JsonResponse
        {
            Message = DomainMessages.ReviewForRestaurant.ReviewDeleted(request.Id)
        };

        return ResultT<JsonResponse>.Success(jsonResponseSuccess);
    }
}