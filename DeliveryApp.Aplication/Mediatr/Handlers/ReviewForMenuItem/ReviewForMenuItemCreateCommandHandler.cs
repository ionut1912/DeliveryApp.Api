using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeliveryApp.Application.Mediatr.Commands.ReviewForMenuItem;
using DeliveryApp.Application.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Messages;

namespace DeliveryApp.Application.Mediatr.Handlers.ReviewForMenuItem
{
    public  class ReviewForMenuItemCreateCommandHandler:ICommandHandler<ReviewForMenuItemCreateCommand,Result>
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

        public async Task<Result> Handle(ReviewForMenuItemCreateCommand request, CancellationToken cancellationToken)
        {
                await _reviewForMenuItemRepository.AddReviewForMenuItem(request.ReviewForMenuItemDto,
                    cancellationToken);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
                return  Result.Success(DomainMessages.ReviewForMenuItem.ReviewCreated);
        }
    }
}
