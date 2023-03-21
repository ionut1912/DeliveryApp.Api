using DeliveryApp.Application.Mediatr.Commands.ReviewForRestaurant;
using DeliveryApp.Application.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Messages;

namespace DeliveryApp.Application.Mediatr.Handlers.ReviewForRestaurant;

public class ReviewForRestaurantCreateCommandHandler : ICommandHandler<ReviewForRestaurantCreateCommand, Result>
{
    private readonly IReviewForRestaurantRepository _reviewForRestaurantRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ReviewForRestaurantCreateCommandHandler(IReviewForRestaurantRepository reviewForRestaurantRepository,
        IUnitOfWork unitOfWork)
    {
        _reviewForRestaurantRepository = reviewForRestaurantRepository ??
                                         throw new ArgumentNullException(nameof(reviewForRestaurantRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<Result> Handle(ReviewForRestaurantCreateCommand request, CancellationToken cancellationToken)
    {
        await _reviewForRestaurantRepository.AddReviewForRestaurant(request.ReviewForRestaurantDto,
            cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success(DomainMessages.ReviewForRestaurant.ReviewCreated);
    }
}