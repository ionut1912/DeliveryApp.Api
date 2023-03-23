using AutoMapper;
using DeliveryApp.Application.Repositories;
using DeliveryApp.Domain.DTO;
using DeliveryApp.Domain.Models;
using DeliveryApp.ExternalServices.Cloudinary.Photo;
using DeliveryApp.Repository.Context;
using DeliveryApp.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace DeliveryApp.Repository.Services;

public class ReviewForRestaurantRepository : IReviewForRestaurantRepository
{
    private readonly DeliveryContext _deliveryContext;
    private readonly IMapper _mapper;
    private readonly IUserAccessor _userAccessor;

    public ReviewForRestaurantRepository(DeliveryContext deliveryContext, IMapper mapper,
        IUserAccessor userAccessor)
    {
        _deliveryContext = deliveryContext ?? throw new ArgumentNullException(nameof(deliveryContext));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _userAccessor = userAccessor ?? throw new ArgumentNullException(nameof(userAccessor));
    }

    public async Task AddReviewForRestaurant(ReviewForRestaurantDto reviewForRestaurantDto,
        CancellationToken cancellationToken)
    {
        var user = await _deliveryContext.Users
            .FirstOrDefaultAsync(x => x.UserName == _userAccessor.GetUsername(), cancellationToken);
        var restaurant = await _deliveryContext.Restaurants
            .Include(x => x.RestaurantPhotos)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == reviewForRestaurantDto.RestaurantId, cancellationToken);
        var reviewForRestaurantEntity = _mapper.Map<ReviewForRestaurants>(reviewForRestaurantDto);
        reviewForRestaurantEntity.Id = Guid.NewGuid();
        reviewForRestaurantEntity.User = user;
        reviewForRestaurantEntity.RestaurantsId = restaurant.Id;
        await _deliveryContext.ReviewForRestaurants.AddAsync(reviewForRestaurantEntity, cancellationToken);
    }

    public async Task<List<ReviewForRestaurant>> GetReviewsForRestaurant(Guid restaurantId,
        CancellationToken cancellationToken)
    {
        var reviewEntities = await _deliveryContext.ReviewForRestaurants
            .Include(x => x.User)
            .ThenInclude(x => x.Photos).Where(x => x.RestaurantsId == restaurantId)
            .AsNoTracking()
            .OrderByDescending(x=>x.NumberOfStars)
            .ToListAsync(cancellationToken);
        return _mapper.Map<List<ReviewForRestaurant>>(reviewEntities);
    }

    public async Task<ReviewForRestaurant> GetReviewForRestaurant(Guid id, Guid restaurantId,
        CancellationToken cancellationToken)
    {
        var reviewForRestaurantEntity = await _deliveryContext.ReviewForRestaurants
            .Include(x => x.User)
            .ThenInclude(x => x.Photos)
            .AsNoTracking()
            .Where(x => x.RestaurantsId == restaurantId)
            .OrderByDescending(x=>x.NumberOfStars)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        return _mapper.Map<ReviewForRestaurant>(reviewForRestaurantEntity);
    }

    public async Task<bool> EditReviewForRestaurant(Guid id, ReviewForRestaurantDto reviewForRestaurantDto,
        CancellationToken cancellationToken)
    {
        var reviewEntity = await _deliveryContext
            .ReviewForRestaurants
            .Include(x => x.User)
            .ThenInclude(x => x.Photos)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (reviewEntity == null) return false;
        var modifiedReview = _mapper.Map(reviewForRestaurantDto, reviewEntity);

        _deliveryContext.ReviewForRestaurants.Update(modifiedReview);

        return true;
    }

    public async Task<bool> DeleteReviewForRestaurant(Guid id, CancellationToken cancellationToken)
    {
        var reviewEntity = await _deliveryContext.ReviewForRestaurants.AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        if (reviewEntity == null) return false;

        _deliveryContext.ReviewForRestaurants.Remove(reviewEntity);
        return true;
    }
}