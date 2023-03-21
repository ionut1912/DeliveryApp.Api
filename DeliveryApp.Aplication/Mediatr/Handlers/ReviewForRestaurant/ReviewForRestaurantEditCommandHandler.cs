using DeliveryApp.Application.Mediatr.Commands.ReviewForRestaurant;
using DeliveryApp.Application.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Messages;

namespace DeliveryApp.Application.Mediatr.Handlers.ReviewForRestaurant;

public class ReviewForRestaurantEditCommandHandler : ICommandHandler<ReviewForRestaurantEditCommand, Result>
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

    public async Task<Result> Handle(ReviewForRestaurantEditCommand request, CancellationToken cancellationToken)
    {
        var result =
            await _reviewForRestaurantRepository.EditReviewForRestaurant(request.Id, request.ReviewForRestaurant,
                cancellationToken);
        if (result is false)
            return Result.Failure(
                DomainMessages.ReviewForRestaurant.CanNotEditReview(request.Id,
                    request.ReviewForRestaurant.RestaurantId));

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success(DomainMessages.ReviewForRestaurant.ReviewEdited(request.Id));
    }
}