using DeliveryApp.Domain.Contracts;
using DeliveryApp.Domain.DTO;
using DeliveryApp.Domain.Models;

namespace DeliveryApp.Application.Repositories;

public interface IReviewForRestaurantRepository
{
    Task AddReviewForRestaurant(ReviewForRestaurantDto reviewForRestaurantDto, CancellationToken cancellationToken);
    Task<List<ReviewForRestaurant>> GetReviewsForRestaurant(Guid restaurantId, CancellationToken cancellationToken);
    Task<ReviewForRestaurant> GetReviewForRestaurant(Guid id, Guid restaurantId, CancellationToken cancellationToken);

    Task<List<CurrentUserReviewForRestaurant>> GetReviewsForRestaurantForCurrentUser(
        CancellationToken cancellationToken);

    Task<bool> EditReviewForRestaurant(Guid id, ReviewForRestaurantDto reviewForRestaurantDto,
        CancellationToken cancellationToken);

    Task<bool> DeleteReviewForRestaurant(Guid id, CancellationToken cancellationToken);
}