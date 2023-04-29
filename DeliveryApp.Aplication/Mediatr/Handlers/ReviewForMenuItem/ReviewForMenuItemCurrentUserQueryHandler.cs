using DeliveryApp.Application.Mediatr.Query.ReviewForMenuItem;
using DeliveryApp.Application.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Contracts;

namespace DeliveryApp.Application.Mediatr.Handlers.ReviewForMenuItem;

public class ReviewForMenuItemCurrentUserQueryHandler : IQueryHandler<ReviewForMenuItemCurrentUserQuery,
    ResultT<List<CurrentUserReviewForMenuItem>>>
{
    private readonly IReviewForMenuItemRepository _reviewForMenuItemRepository;

    public ReviewForMenuItemCurrentUserQueryHandler(IReviewForMenuItemRepository reviewForMenuItemRepository)
    {
        _reviewForMenuItemRepository = reviewForMenuItemRepository ??
                                       throw new ArgumentNullException(nameof(reviewForMenuItemRepository));
    }

    public async Task<ResultT<List<CurrentUserReviewForMenuItem>>> Handle(ReviewForMenuItemCurrentUserQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _reviewForMenuItemRepository.GetReviewsForCurrentUser(cancellationToken);
        return ResultT<List<CurrentUserReviewForMenuItem>>.Success(result);
    }
}