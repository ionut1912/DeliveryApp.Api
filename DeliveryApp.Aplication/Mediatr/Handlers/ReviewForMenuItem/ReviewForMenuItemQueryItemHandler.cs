using DeliveryApp.Application.Mediatr.Query.ReviewForMenuItem;
using DeliveryApp.Application.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Messages;

namespace DeliveryApp.Application.Mediatr.Handlers.ReviewForMenuItem;

public class
    ReviewForMenuItemQueryItemHandler : IQueryHandler<ReviewForMenuItemQueryItem,
        ResultT<Domain.Models.ReviewForMenuItem>>
{
    private readonly IReviewForMenuItemRepository _reviewForMenuItemRepository;

    public ReviewForMenuItemQueryItemHandler(IReviewForMenuItemRepository reviewForMenuItemRepository)
    {
        _reviewForMenuItemRepository = reviewForMenuItemRepository ??
                                       throw new ArgumentNullException(nameof(reviewForMenuItemRepository));
    }

    public async Task<ResultT<Domain.Models.ReviewForMenuItem>> Handle(ReviewForMenuItemQueryItem request,
        CancellationToken cancellationToken)
    {
        var result =
            await _reviewForMenuItemRepository.GetReviewForMenuItem(request.Id, request.MenuItemId,
                cancellationToken);
        return result == null
            ? ResultT<Domain.Models.ReviewForMenuItem>.Failure(DomainMessagesEn.ReviewForMenuItem.NotFound(request.Id))
            : ResultT<Domain.Models.ReviewForMenuItem>.Success(result);
    }
}