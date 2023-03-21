using DeliveryApp.Application.Mediatr.Query.ReviewForRestaurant;
using DeliveryApp.Application.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;

namespace DeliveryApp.Application.Mediatr.Handlers.ReviewForRestaurant;

public class ReviewForRestaurantListQueryHandler : IQueryHandler<ReviewForRestaurantListQuery,
    ResultT<List<Domain.Models.ReviewForRestaurant>>>
{
    private readonly IReviewForRestaurantRepository _reviewForRestaurantRepository;

    public ReviewForRestaurantListQueryHandler(IReviewForRestaurantRepository reviewForRestaurantRepository)
    {
        _reviewForRestaurantRepository = reviewForRestaurantRepository ??
                                         throw new ArgumentNullException(nameof(reviewForRestaurantRepository));
    }

    public async Task<ResultT<List<Domain.Models.ReviewForRestaurant>>> Handle(ReviewForRestaurantListQuery request,
        CancellationToken cancellationToken)
    {
        var result =
            await _reviewForRestaurantRepository.GetReviewsForRestaurant(request.RestaurantId, cancellationToken);
        return ResultT<List<Domain.Models.ReviewForRestaurant>>.Success(result);
    }
}