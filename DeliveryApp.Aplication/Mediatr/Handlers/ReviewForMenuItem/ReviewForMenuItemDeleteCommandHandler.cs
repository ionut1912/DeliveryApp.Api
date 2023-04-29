using DeliveryApp.Application.Mediatr.Commands.ReviewForMenuItem;
using DeliveryApp.Application.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Messages;

namespace DeliveryApp.Application.Mediatr.Handlers.ReviewForMenuItem;

public class
    ReviewForMenuItemDeleteCommandHandler : ICommandHandler<ReviewForMenuItemDeleteCommand, ResultT<JsonResponse>>
{
    private readonly IReviewForMenuItemRepository _reviewForMenuItemRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ReviewForMenuItemDeleteCommandHandler(IReviewForMenuItemRepository reviewForMenuItemRepository,
        IUnitOfWork unitOfWork)
    {
        _reviewForMenuItemRepository = reviewForMenuItemRepository ??
                                       throw new ArgumentNullException(nameof(reviewForMenuItemRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<ResultT<JsonResponse>> Handle(ReviewForMenuItemDeleteCommand request,
        CancellationToken cancellationToken)
    {
        var result =
            await _reviewForMenuItemRepository.DeleteReviewForMenuItem(request.Id,
                cancellationToken);
        if (result is false)
        {
            var jsonResponseFailure = new JsonResponse
            {
                Message = request.Request.Language == "EN"
                    ? DomainMessagesEn.ReviewForMenuItem.CanNoDeleteReview(request.Id)
                    : DomainMessagesRo.ReviewForMenuItem.CanNoDeleteReview(request.Id)
            };
            return ResultT<JsonResponse>.Failure(jsonResponseFailure.Message);
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        var jsonResponseSuccess = new JsonResponse
        {
            Message = request.Request.Language == "EN"
                ? DomainMessagesEn.ReviewForMenuItem.ReviewDeleted(request.Id)
                : DomainMessagesRo.ReviewForMenuItem.ReviewDeleted(request.Id)
        };

        return ResultT<JsonResponse>.Success(jsonResponseSuccess);
    }
}