using DeliveryApp.Application.Mediatr.Commands.ReviewForMenuItem;
using DeliveryApp.Application.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Messages;

namespace DeliveryApp.Application.Mediatr.Handlers.ReviewForMenuItem;

public class
    ReviewForMenuItemCreateCommandHandler : ICommandHandler<ReviewForMenuItemCreateCommand, ResultT<JsonResponse>>
{
    private readonly IReviewForMenuItemRepository _reviewForMenuItemRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ReviewForMenuItemCreateCommandHandler(IReviewForMenuItemRepository reviewForMenuItemRepository,
        IUnitOfWork unitOfWork)
    {
        _reviewForMenuItemRepository = reviewForMenuItemRepository ??
                                       throw new ArgumentNullException(nameof(reviewForMenuItemRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<ResultT<JsonResponse>> Handle(ReviewForMenuItemCreateCommand request,
        CancellationToken cancellationToken)
    {
        await _reviewForMenuItemRepository.AddReviewForMenuItem(request.Request.ReviewForMenuItemDto,
            cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        var jsonResponseSuccess = new JsonResponse
        {
            Message = request.Request.Language == "EN"
                ? DomainMessagesEn.ReviewForMenuItem.ReviewCreated
                : DomainMessagesRo.ReviewForMenuItem.ReviewCreated
        };

        return ResultT<JsonResponse>.Success(jsonResponseSuccess);
    }
}