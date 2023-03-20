
using AutoMapper;
using DeliveryApp.Application.Repositories;
using DeliveryApp.Domain.DTO;
using DeliveryApp.Domain.Models;
using DeliveryApp.ExternalServices.Cloudinary.Photo;
using DeliveryApp.Repository.Context;
using DeliveryApp.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace DeliveryApp.Repository.Services
{
    public class ReviewForMenuItemService:IReviewForMenuItemRepository
    {
        private readonly DeliveryContext _deliveryContext;
        private  readonly  IMapper _mapper;
        private  readonly  IUserAccessor _userAccessor;

        public ReviewForMenuItemService(DeliveryContext deliveryContext, IMapper mapper,IUserAccessor userAccessor)
        {
            _deliveryContext = deliveryContext ?? throw new ArgumentNullException(nameof(deliveryContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _userAccessor=userAccessor?? throw  new ArgumentNullException(nameof(userAccessor));
        }

        public async Task AddReviewForMenuItem(ReviewForMenuItemDto reviewForMenuItemDto, CancellationToken cancellationToken)
        {
            var user = await _deliveryContext.Users.AsNoTracking()
                .FirstOrDefaultAsync(x => x.UserName == _userAccessor.GetUsername(), cancellationToken);
            var menuItem = await _deliveryContext.MenuItems.AsNoTracking().Include(x=>x.Photos)
                .FirstOrDefaultAsync(x => x.Id == reviewForMenuItemDto.MenuItemId, cancellationToken);
            var reviewForMenuItemEntity = _mapper.Map<ReviewForMenuItems>(reviewForMenuItemDto);
            reviewForMenuItemEntity.Id=Guid.NewGuid();
            reviewForMenuItemEntity.User = user;

            menuItem.Reviews.Add(reviewForMenuItemEntity);
            await _deliveryContext.ReviewForMenuItems.AddAsync(reviewForMenuItemEntity, cancellationToken);
            _deliveryContext.MenuItems.Update(menuItem);
            _deliveryContext.Users.Update(user);

        }

        public async Task<List<ReviewForMenuItem>> GetReviewsForMenuItem(Guid menuItemId, CancellationToken cancellationToken)
        {
            var reviewEntities = await _deliveryContext.ReviewForMenuItems.AsNoTracking().Include(x => x.User)
                .ThenInclude(x => x.Photos).Where(x=>x.MenuItemsId==menuItemId).ToListAsync(cancellationToken);
            return _mapper.Map<List<ReviewForMenuItem>>(reviewEntities);
            
        }

        public async Task<ReviewForMenuItem> GetReviewForMenuItem(Guid id,Guid menuItemId, CancellationToken cancellationToken)
        {
            var reviewForMenuItemEntity = await _deliveryContext.ReviewForMenuItems.AsNoTracking().Include(x => x.User)
                .ThenInclude(x => x.Photos).Where(x=>x.MenuItemsId==menuItemId).FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            return _mapper.Map<ReviewForMenuItem>(reviewForMenuItemEntity);
        }

        public async Task<bool> EditReviewForMenuItem(Guid id, ReviewForMenuItemDto reviewForMenuItemDto, CancellationToken cancellationToken)
        {
            
            var reviewEntity = await _deliveryContext.ReviewForMenuItems.AsNoTracking()
                .Include(x=>x.User)
                .ThenInclude(x=>x.Photos)
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            var menuItem = await _deliveryContext.MenuItems.AsNoTracking().Include(x => x.Photos)
                .FirstOrDefaultAsync(x => x.Id == reviewForMenuItemDto.MenuItemId, cancellationToken);
            var user = await _deliveryContext.Users.AsNoTracking().Include(x=>x.ReviewsForMenuItems)
                .FirstOrDefaultAsync(x => x.UserName == _userAccessor.GetUsername(), cancellationToken);
            if (reviewEntity == null) return false;
            var modifiedReview = _mapper.Map(reviewForMenuItemDto, reviewEntity);
            menuItem.Reviews= menuItem.Reviews
                .Select(x => x.Id == reviewEntity.Id ? new ReviewForMenuItems{ Id =reviewEntity.Id, ReviewTitle = reviewEntity.ReviewTitle, ReviewDescription = reviewEntity.ReviewDescription,User = reviewEntity.User} : x)
                .ToList();
            user.ReviewsForMenuItems=user.ReviewsForMenuItems.Select(x => x.Id == reviewEntity.Id ? new ReviewForMenuItems { Id = reviewEntity.Id, ReviewTitle = reviewEntity.ReviewTitle, ReviewDescription = reviewEntity.ReviewDescription, User = reviewEntity.User } : x)
                .ToList();
            _deliveryContext.ReviewForMenuItems.Update(modifiedReview);
            _deliveryContext.MenuItems.Update(menuItem);
            _deliveryContext.Users.Update(user);

            return true;

        }

        public async Task<bool> DeleteReviewForMenuItem(Guid id,Guid menuItemId, CancellationToken cancellationToken)
        {
            var reviewEntity = await _deliveryContext.ReviewForMenuItems.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            if (reviewEntity == null) return false;
            var menuItem =
                await _deliveryContext.MenuItems.Include(x=>x.Reviews).FirstOrDefaultAsync(x => x.Id== menuItemId, cancellationToken);
            var user = await _deliveryContext.Users.AsNoTracking().Include(x=>x.ReviewsForMenuItems)
                .FirstOrDefaultAsync(x => x.UserName == _userAccessor.GetUsername(), cancellationToken);
            menuItem.Reviews.Remove(reviewEntity);
            user.ReviewsForMenuItems.Remove(reviewEntity);
            _deliveryContext.ReviewForMenuItems.Remove(reviewEntity);
            _deliveryContext.MenuItems.Update(menuItem);
            _deliveryContext.Users.Update(user);
            return true;
        }
    }
}
