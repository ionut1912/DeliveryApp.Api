using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeliveryApp.Application.Mediatr.Commands.ReviewForMenuItem;
using DeliveryApp.Application.Mediatr.CommandValidators.ReviewForMenuItem;
using DeliveryApp.Application.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Messages;
using FluentValidation;

namespace DeliveryApp.Application.Mediatr.Handlers.ReviewForMenuItem
{
    public class ReviewForMenuItemEditCommandHandler:ICommandHandler<ReviewForMenuItemEditCommand,Result>
    {
        private readonly IReviewForMenuItemRepository _reviewForMenuItemRepository;
        private  readonly  IUnitOfWork _unitOfWork;

        public ReviewForMenuItemEditCommandHandler(IReviewForMenuItemRepository reviewForMenuItemRepository,
            IUnitOfWork unitOfWork)
        {
            _reviewForMenuItemRepository = reviewForMenuItemRepository ??
                                           throw new ArgumentNullException(nameof(reviewForMenuItemRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<Result> Handle(ReviewForMenuItemEditCommand request, CancellationToken cancellationToken)
        {
            var result =
                await _reviewForMenuItemRepository.EditReviewForMenuItem(request.Id,request.ReviewForMenuItemDto,
                    cancellationToken);
            if (result is false)
            {
                return  Result.Failure(DomainMessages.ReviewForMenuItem.CanNotEditReview(request.Id,request.ReviewForMenuItemDto.MenuItemId));
            }

            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return  Result.Success(DomainMessages.ReviewForMenuItem.ReviewEdited(request.Id));

        }
    }
}
