using DeliveryApp.Domain.Contracts;
using DeliveryApp.Domain.DTO;
using DeliveryApp.Domain.Models;

namespace DeliveryApp.Application.Repositories;

public interface IReviewForMenuItemRepository
{
    Task AddReviewForMenuItem(ReviewForMenuItemDto reviewForMenuItemDto, CancellationToken cancellationToken);
    Task<List<ReviewForMenuItem>> GetReviewsForMenuItem(Guid menuItemId, CancellationToken cancellationToken);
    Task<ReviewForMenuItem> GetReviewForMenuItem(Guid id, Guid menuItemId, CancellationToken cancellationToken);

    Task<bool> EditReviewForMenuItem(Guid id, ReviewForMenuItemDto reviewForMenuItemDto,
        CancellationToken cancellationToken);

    Task<bool> DeleteReviewForMenuItem(Guid id, CancellationToken cancellationToken);
    Task<List<CurrentUserReviewForMenuItem>> GetReviewsForCurrentUser(CancellationToken cancellationToken);
}