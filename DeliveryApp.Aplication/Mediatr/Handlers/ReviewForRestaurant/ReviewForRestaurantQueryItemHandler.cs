using DeliveryApp.Application.Mediatr.Query.ReviewForRestaurant;
using DeliveryApp.Application.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Messages;

namespace DeliveryApp.Application.Mediatr.Handlers.ReviewForRestaurant;

public class
    ReviewForRestaurantQueryItemHandler : IQueryHandler<ReviewForRestaurantQueryItem,
        ResultT<Domain.Models.ReviewForRestaurant>>
{
    private readonly IReviewForRestaurantRepository _reviewForRestaurantRepository;

    public ReviewForRestaurantQueryItemHandler(IReviewForRestaurantRepository reviewForRestaurantRepository)
    {
        _reviewForRestaurantRepository = reviewForRestaurantRepository ??
                                         throw new ArgumentNullException(nameof(reviewForRestaurantRepository));
    }

    public async Task<ResultT<Domain.Models.ReviewForRestaurant>> Handle(ReviewForRestaurantQueryItem request,
        CancellationToken cancellationToken)
    {
        var result =
            await _reviewForRestaurantRepository.GetReviewForRestaurant(request.Id, request.RestaurantId,
                cancellationToken);
        return result == null
            ? ResultT<Domain.Models.ReviewForRestaurant>.Failure(
                DomainMessagesEn.ReviewForRestaurant.NotFound(request.Id))
            : ResultT<Domain.Models.ReviewForRestaurant>.Success(result);
    }
}