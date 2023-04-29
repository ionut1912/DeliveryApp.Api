using System.Collections.Immutable;
using AutoMapper;
using DeliveryApp.Application.Mediatr.Query.Account;
using DeliveryApp.Application.Repositories;
using DeliveryApp.Domain.Contracts;
using DeliveryApp.Domain.DTO;
using DeliveryApp.Domain.Models;
using DeliveryApp.ExternalServices.Cloudinary.Photo;
using DeliveryApp.Repository.Context;
using DeliveryApp.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace DeliveryApp.Repository.Services;

public class ReviewForMenuItemService : IReviewForMenuItemRepository
{
    private readonly DeliveryContext _deliveryContext;
    private readonly IMapper _mapper;
    private readonly IUserAccessor _userAccessor;

    public ReviewForMenuItemService(DeliveryContext deliveryContext, IMapper mapper, IUserAccessor userAccessor)
    {
        _deliveryContext = deliveryContext ?? throw new ArgumentNullException(nameof(deliveryContext));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _userAccessor = userAccessor ?? throw new ArgumentNullException(nameof(userAccessor));
    }

    public async Task AddReviewForMenuItem(ReviewForMenuItemDto reviewForMenuItemDto,
        CancellationToken cancellationToken)
    {
        var user = await _deliveryContext.Users
            .FirstOrDefaultAsync(x => x.UserName == _userAccessor.GetUsername(), cancellationToken);
        var menuItem = await _deliveryContext.MenuItems
            .Include(x => x.Photos)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == reviewForMenuItemDto.MenuItemId, cancellationToken);
        var reviewForMenuItemEntity = _mapper.Map<ReviewForMenuItems>(reviewForMenuItemDto);
        reviewForMenuItemEntity.Id = Guid.NewGuid();
        reviewForMenuItemEntity.User = user;
        reviewForMenuItemEntity.MenuItemsId = menuItem.Id;
        await _deliveryContext.ReviewForMenuItems.AddAsync(reviewForMenuItemEntity, cancellationToken);
    }

    public async Task<List<ReviewForMenuItem>> GetReviewsForMenuItem(Guid menuItemId,
        CancellationToken cancellationToken)
    {
        var reviewEntities = await _deliveryContext.ReviewForMenuItems
            .Include(x => x.User)
            .ThenInclude(x => x.Photos).Where(x => x.MenuItemsId == menuItemId)
            .AsNoTracking().OrderByDescending(x => x.NumberOfStars)
            .ToListAsync(cancellationToken);
        return _mapper.Map<List<ReviewForMenuItem>>(reviewEntities);
    }

    public async Task<ReviewForMenuItem> GetReviewForMenuItem(Guid id, Guid menuItemId,
        CancellationToken cancellationToken)
    {
        var reviewForMenuItemEntity = await _deliveryContext.ReviewForMenuItems
            .Include(x => x.User)
            .ThenInclude(x => x.Photos)
            .AsNoTracking()
            .Where(x => x.MenuItemsId == menuItemId)
            .OrderByDescending(x => x.NumberOfStars)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        return _mapper.Map<ReviewForMenuItem>(reviewForMenuItemEntity);
    }

    public async Task<bool> EditReviewForMenuItem(Guid id, ReviewForMenuItemDto reviewForMenuItemDto,
        CancellationToken cancellationToken)
    {
        var reviewEntity = await _deliveryContext
            .ReviewForMenuItems
            .Include(x => x.User)
            .ThenInclude(x => x.Photos)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (reviewEntity == null) return false;
        var modifiedReview = _mapper.Map(reviewForMenuItemDto, reviewEntity);

        _deliveryContext.ReviewForMenuItems.Update(modifiedReview);

        return true;
    }

    public async Task<bool> DeleteReviewForMenuItem(Guid id, CancellationToken cancellationToken)
    {
        var reviewEntity = await _deliveryContext.ReviewForMenuItems.AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        if (reviewEntity == null) return false;

        _deliveryContext.ReviewForMenuItems.Remove(reviewEntity);
        return true;
    }

    public async Task<List<CurrentUserReviewForMenuItem>> GetReviewsForCurrentUser(CancellationToken cancellationToken)
    {
        var reviews = await _deliveryContext.ReviewForMenuItems.Include(x=>x.User).Where(x => x.User.UserName == _userAccessor.GetUsername())
            .AsNoTracking().ToListAsync(cancellationToken);


        return reviews.Select(t => new CurrentUserReviewForMenuItem
            {
                Id = t.Id,
                ReviewTitle = t.ReviewTitle,
                ReviewDescription = t.ReviewDescription,
                NumberOfStars = t.NumberOfStars,
                Username = t.User.UserName,
                ItemName = _deliveryContext.MenuItems.FirstOrDefaultAsync(x => x.Id == reviews[0].MenuItemsId, cancellationToken).Result.ItemName
            })
            .ToList();
    }
}