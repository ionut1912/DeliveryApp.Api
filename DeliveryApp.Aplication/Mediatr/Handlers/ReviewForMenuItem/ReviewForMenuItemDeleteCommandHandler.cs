using DeliveryApp.Application.Mediatr.CommandValidators.ReviewForMenuItem;
using DeliveryApp.Application.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Messages;

namespace DeliveryApp.Application.Mediatr.Handlers.ReviewForMenuItem;

public class ReviewForMenuItemDeleteCommandHandler : ICommandHandler<ReviewForMenuItemDeleteCommand, Result>
{
    private readonly IReviewForMenuItemRepository _rebvForMenuItemRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ReviewForMenuItemDeleteCommandHandler(IReviewForMenuItemRepository rebvForMenuItemRepository,
        IUnitOfWork unitOfWork)
    {
        _rebvForMenuItemRepository = rebvForMenuItemRepository ??
                                     throw new ArgumentNullException(nameof(rebvForMenuItemRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<Result> Handle(ReviewForMenuItemDeleteCommand request, CancellationToken cancellationToken)
    {
        var result =
            await _rebvForMenuItemRepository.DeleteReviewForMenuItem(request.Id,
                cancellationToken);
        if (result is false)
            return Result.Failure(DomainMessages.ReviewForMenuItem.CanNoDeleteReview(request.Id));

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success(DomainMessages.ReviewForMenuItem.ReviewDeleted(request.Id));
    }
}