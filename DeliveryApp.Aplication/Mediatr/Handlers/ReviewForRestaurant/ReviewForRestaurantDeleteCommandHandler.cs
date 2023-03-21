using DeliveryApp.Application.Mediatr.CommandValidators.ReviewForRestaurant;
using DeliveryApp.Application.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Messages;

namespace DeliveryApp.Application.Mediatr.Handlers.ReviewForRestaurant;

public class ReviewForRestaurantDeleteCommandHandler : ICommandHandler<ReviewForRestaurantDeleteCommand, Result>
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

    public async Task<Result> Handle(ReviewForRestaurantDeleteCommand request, CancellationToken cancellationToken)
    {
        var result = await _reviewForRestaurantRepository.DeleteReviewForRestaurant(request.Id, cancellationToken);
        if (result is false) return Result.Failure(DomainMessages.ReviewForRestaurant.CanNoDeleteReview(request.Id));

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success(DomainMessages.ReviewForRestaurant.ReviewDeleted(request.Id));
    }
}