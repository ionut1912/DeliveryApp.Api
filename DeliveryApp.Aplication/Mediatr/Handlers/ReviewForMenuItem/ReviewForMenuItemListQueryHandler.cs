using DeliveryApp.Application.Mediatr.Query.ReviewForMenuItem;
using DeliveryApp.Application.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;

namespace DeliveryApp.Application.Mediatr.Handlers.ReviewForMenuItem;

public class
    ReviewForMenuItemListQueryHandler : IQueryHandler<ReviewForMenuItemListQuery,
        ResultT<List<Domain.Models.ReviewForMenuItem>>>
{
    private readonly IReviewForMenuItemRepository _reviewForMenuItemRepository;

    public ReviewForMenuItemListQueryHandler(IReviewForMenuItemRepository reviewForMenuItemRepository)
    {
        _reviewForMenuItemRepository = reviewForMenuItemRepository ??
                                       throw new ArgumentNullException(nameof(reviewForMenuItemRepository));
    }

    public async Task<ResultT<List<Domain.Models.ReviewForMenuItem>>> Handle(ReviewForMenuItemListQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _reviewForMenuItemRepository.GetReviewsForMenuItem(request.MenuItemId, cancellationToken);
        return ResultT<List<Domain.Models.ReviewForMenuItem>>.Success(result);
    }
}