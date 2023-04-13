﻿using DeliveryApp.Application.Mediatr.Commands.ReviewForMenuItem;
using DeliveryApp.Application.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Messages;

namespace DeliveryApp.Application.Mediatr.Handlers.ReviewForMenuItem;

public class ReviewForMenuItemEditCommandHandler : ICommandHandler<ReviewForMenuItemEditCommand, ResultT<JsonResponse>>
{
    private readonly IReviewForMenuItemRepository _reviewForMenuItemRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ReviewForMenuItemEditCommandHandler(IReviewForMenuItemRepository reviewForMenuItemRepository,
        IUnitOfWork unitOfWork)
    {
        _reviewForMenuItemRepository = reviewForMenuItemRepository ??
                                       throw new ArgumentNullException(nameof(reviewForMenuItemRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<ResultT<JsonResponse>> Handle(ReviewForMenuItemEditCommand request,
        CancellationToken cancellationToken)
    {
        var result =
            await _reviewForMenuItemRepository.EditReviewForMenuItem(request.Id, request.ReviewForMenuItemDto,
                cancellationToken);
        if (result is false)
        {
            var jsonResponseFailure = new JsonResponse
            {
                Message = DomainMessages.ReviewForMenuItem.CanNotEditReview(request.Id,
                    request.ReviewForMenuItemDto.MenuItemId)
            };
            return ResultT<JsonResponse>.Failure(jsonResponseFailure.Message);
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        var jsonResponseSuccess = new JsonResponse
        {
            Message = DomainMessages.ReviewForMenuItem.ReviewEdited(request.Id)
        };
        return ResultT<JsonResponse>.Success(jsonResponseSuccess);
    }
}